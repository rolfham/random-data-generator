using Futurez.XrmToolBox.Controls;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using random_data_generator.RandomData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using AttributeTypeCode = Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode;
using Label = System.Windows.Forms.Label;

namespace random_data_generator
{

    public partial class DataGeneratorControl : PluginControlBase, IGitHubPlugin, IAboutPlugin, IStatusBarMessager
    {

        //These type codes are not yet supported by the tool. Attributes with these typecodes won't be listed. 
        private readonly List<AttributeTypeCode> _unsupportedAttributeTypeCodes = new List<AttributeTypeCode>
        {
            AttributeTypeCode.Memo,
            AttributeTypeCode.ManagedProperty,
            AttributeTypeCode.CalendarRules,
            AttributeTypeCode.PartyList,
            AttributeTypeCode.Status,
            AttributeTypeCode.Uniqueidentifier,
            AttributeTypeCode.Virtual,
            AttributeTypeCode.EntityName
          };

        private List<Attribute> _attributes = new List<Attribute>();
        private readonly List<Attribute> _selectedAttributes = new List<Attribute>();
        private readonly Font _defaultFont = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private string _selectedEntity = string.Empty;
        public DataGeneratorControl()
        {
            InitializeComponent();
        }

        private void DoStuffWhenSelectingEntity(object sender, EntitiesDropdownControl.SelectedItemChangedEventArgs e)
        {
            var selected = entityDropdown.SelectedEntity;
            if (selected == null)
            {
                listbox.Enabled = false;
                return;
            }
            LookupHelper.Cache.Dispose();

            if (selected.LogicalName == _selectedEntity)
                return;
            _selectedEntity = selected.LogicalName;

            _attributes.Clear();
            _selectedAttributes.Clear();
            listbox.Items.Clear();

            for (var i = panel2.Controls.Count - 1; i >= 0; i--)
            {
                if (panel2.Controls[i].Name != lblDataType.Name)
                    panel2.Controls.RemoveAt(i);
            }

            panel3.Visible = false;
            listbox.Enabled = true;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving metadata",
                Work = (worker, args) =>
                {
                    var metadataRequest = new RetrieveEntityRequest { EntityFilters = EntityFilters.Attributes, LogicalName = selected.LogicalName };
                    args.Result = (RetrieveEntityResponse)Service.Execute(metadataRequest);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show($"Failed to execute RetrieveEntityRequest. Error message:\n{args.Error}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var result = (RetrieveEntityResponse)args.Result;
                    AddAttributesToListBox(result);
                }
            });

        }

        private void AddAttributesToListBox(RetrieveEntityResponse metadata)
        {
            var attributeMetas = metadata.EntityMetadata.Attributes;

            foreach (var attributeMetadata in attributeMetas)
            {
                if (attributeMetadata.DisplayName.UserLocalizedLabel == null || string.IsNullOrWhiteSpace(attributeMetadata.DisplayName.UserLocalizedLabel.Label))
                    continue;

                if (attributeMetadata.AttributeType == null)
                    continue;

                if (attributeMetadata.IsValidForCreate == false)
                    continue;

                if (_unsupportedAttributeTypeCodes.Contains((AttributeTypeCode)attributeMetadata.AttributeType))
                    continue;

                _attributes.Add(new Attribute(attributeMetadata));
            }

            _attributes = _attributes.OrderBy(o => o.DisplayName).ToList();

            foreach (var attribute in _attributes)
            {
                listbox.Items.Add(attribute, attribute.IsPrimaryName ? CheckState.Checked : CheckState.Unchecked);
            }

        }

        private void DoStuffWhenSelectingAField(object sender, ItemCheckEventArgs e)
        {
            if (!(listbox.Items[e.Index] is Attribute selectedAttribute))
                return;

            if (e.CurrentValue == CheckState.Checked)
            {
                _selectedAttributes.Remove(selectedAttribute);
                for (var i = panel2.Controls.Count - 1; i >= 0; i--)
                {
                    if (panel2.Controls[i].Name.Contains(selectedAttribute.LogicalName))
                        panel2.Controls.RemoveAt(i);
                }

                if (panel2.Controls.Count == 1)
                {
                    panel3.Visible = false;
                    lblDataType.Visible = false;
                }

                return;
            }
            lblDataType.Visible = true;
            _selectedAttributes.Add(selectedAttribute);

            List<string> validTypes;
            try
            {
                validTypes = DataTypeHelper.GetValidTypes(selectedAttribute.TypeCode);
            }
            catch (NotImplementedException exception)
            {
                e.NewValue = e.CurrentValue;
                MessageBox.Show(exception.Message);
                return;
            }

            var l = new Label
            {
                Font = _defaultFont,
                Margin = new Padding(10, 3, 3, 0),
                Text = selectedAttribute.DisplayName,
                Dock = DockStyle.Top,
                Name = $"lbl{selectedAttribute.LogicalName}",
                Anchor = AnchorStyles.Top,
                Width = panel2.Width
            };

            var c = new ComboBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(10, 3, 3, 20),
                Font = _defaultFont,
                Name = $"{selectedAttribute.LogicalName}",
                Anchor = AnchorStyles.Top,
                Width = Convert.ToInt32(panel2.Width * 0.8),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            c.SelectedValueChanged += (o, args) =>
            {
                selectedAttribute.SetTypeOfData(c.Text);
            };


            foreach (var validType in validTypes)
            {
                c.Items.Add(validType);
            }

            c.SelectedItem = selectedAttribute.GetDefaultDataType();

            panel2.Controls.Add(l);
            panel2.Controls.Add(c);
            panel3.Visible = true;

        }

        private void OnLoad(object sender, EventArgs e)
        {
            listbox.CheckOnClick = true;
            panel2.HorizontalScroll.Maximum = 0;
            panel2.AutoScroll = true;
            entityDropdown.ParentBaseControl = this;
            entityDropdown.Service = Service;
            entityDropdown.AutoLoadData = true;

        }

        private void GenerateData(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Generating random data",
                Work = (worker, args) =>
                {
                    var list = new List<OrganizationRequest>();
                    for (var i = 0; i < (int)numberOfRecordsControl.Value; i++)
                    {
                        list.Add(new EntityWithRandomData(Service, _selectedAttributes).GetCreateRequest());
                    }

                    args.Result = list;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show($"Something bad happened. Error message:\n{args.Error}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var result = (List<OrganizationRequest>)args.Result;
                    ExecuteMultipleRequests(result);
                }
            });

        }

        private void ExecuteMultipleRequests(List<OrganizationRequest> requests)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating entity records",
                Work = (worker, args) =>
                {
                    var responses = new ExecuteMultipleResponseItemCollection();
                    var lists = SplitList(requests);
                    var count = 0;
                    foreach (var list in lists)
                    {
                        var collection = new OrganizationRequestCollection();
                        collection.AddRange(list);
                        var req = new ExecuteMultipleRequest
                        {
                            Requests = collection,
                            Settings = new ExecuteMultipleSettings {ContinueOnError = true, ReturnResponses = false}
                        };
                        count++;
                        var response = (ExecuteMultipleResponse)Service.Execute(req);
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(count / requests.Count, $"{count}/{requests.Count} records created"));
                        responses.AddRange(response.Responses);
                    }

                    args.Result = responses;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show($"Something bad happened. Error message:\n{args.Error}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var result = (ExecuteMultipleResponseItemCollection)args.Result;
                    if (result.Count == 0)
                    {
                        MessageBox.Show($"{requests.Count} records successfully created"); 
                    }
                    else
                    {
                        var createdCount = requests.Count - result.Count;
                        MessageBox.Show($"{createdCount}/{requests.Count} records created. See error log for details.");

                        foreach (var response in result)
                        {
                            LogError(response.Fault.Message);
                        }
                    }

                },
                IsCancelable = true,
            });
            
        }
        private static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 10)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        #region public members
        public string RepositoryName => "random-data-generator";
        public string UserName => "rolfham";

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        public void ShowAboutDialog()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}