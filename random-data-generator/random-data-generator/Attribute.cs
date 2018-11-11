using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using random_data_generator.RandomData;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace random_data_generator
{
    public class Attribute
    {
        public string DisplayName { get; }
        public string LogicalName { get; }
        public AttributeTypeCode TypeCode { get; }
        public bool IsPrimaryName { get; }
        public string EntityName { get; }

        private readonly AttributeMetadata _metadata;
        public string TypeOfDataToBeGenerated { get; set; }
        public Attribute(AttributeMetadata metadata)
        {
            DisplayName = metadata.DisplayName.UserLocalizedLabel.Label;
            LogicalName = metadata.LogicalName;
            EntityName = metadata.EntityLogicalName;
            Debug.Assert(metadata.AttributeType != null, "metadata.AttributeType != null");
            TypeCode = (AttributeTypeCode)metadata.AttributeType;
            IsPrimaryName = metadata.IsPrimaryName == true;
            _metadata = metadata;
        }

        public string GetDefaultDataType()
        {
            if (LogicalName.Contains("firstname"))
                return DataTypeHelper.FirstName;

            if (LogicalName.Contains("lastname"))
                return DataTypeHelper.LastName;

            if (LogicalName.Contains("fullname"))
                return DataTypeHelper.Name;

            if (LogicalName == "customerid")
                return DataTypeHelper.Customer;

            if (LogicalName.Contains("birthday"))
                return DataTypeHelper.DatePast;

            if (LogicalName.Contains("country"))
                return DataTypeHelper.Country;

            if (LogicalName.Contains("city"))
                return DataTypeHelper.City;

            if (LogicalName.Contains("street") || LogicalName.Contains("_line1"))
                return DataTypeHelper.Street;

            if (LogicalName.Contains("email"))
                return DataTypeHelper.Email;

            if (LogicalName.Contains("phone") || LogicalName.Contains("mobile"))
                return DataTypeHelper.PhoneNumber;

            if (EntityName == "account" && LogicalName == "name")
                return DataTypeHelper.CompanyNames;

            return DataTypeHelper.GetValidTypes(TypeCode)[0];
        }

        private static readonly Random Random = new Random();

        private static string RandomStringValue(IReadOnlyList<string> list)
        {
            return list[Random.Next(0, list.Count - 1)];
        }



        public object GetRandomData(IOrganizationService service)
        {
            switch (TypeOfDataToBeGenerated)
            {
                case DataTypeHelper.CompanyNames:
                    return RandomStringValue(StringValues.CompanyNames);

                case DataTypeHelper.FirstName:
                    return RandomStringValue(StringValues.FirstNames);

                case DataTypeHelper.LastName:
                    return RandomStringValue(StringValues.LastNames);

                case DataTypeHelper.Name:
                    var first = RandomStringValue(StringValues.FirstNames);
                    var last = RandomStringValue(StringValues.LastNames);
                    return $"{first} {last}";

                case DataTypeHelper.PhoneNumber:
                    return $"+{Random.Next(1, 50)}-{Random.Next(100, 900)}-555-{Random.Next(100, 999)}";
                case DataTypeHelper.Age:
                    return Random.Next(1, 116);

                case DataTypeHelper.Email:
                    return RandomStringValue(StringValues.Emails);

                case DataTypeHelper.LoremSmall:
                    return StringValues.LoremIpsumSmall;

                case DataTypeHelper.LoremBig:
                    return StringValues.LoremIpsumBig;

                case DataTypeHelper.WholeNumber:
                    return Random.Next(-100000, 100000);

                case DataTypeHelper.WholeNumberOneToTen:
                    return Random.Next(1, 10);

                case DataTypeHelper.WholeNumberNegative:
                    return Random.Next(-100, -1);

                case DataTypeHelper.WholeNumberPositive:
                    return Random.Next(1, 100);

                case DataTypeHelper.Date:
                    return DateTimeHelper.GetRandomDate(Random);

                case DataTypeHelper.DateFuture:
                    return DateTimeHelper.GetFutureDate(Random);

                case DataTypeHelper.DatePast:
                    return DateTimeHelper.GetPastDate(Random);

                case DataTypeHelper.DateFuture30:
                    return DateTimeHelper.Next30Days(Random);

                case DataTypeHelper.DatePast30:
                    return DateTimeHelper.Last30Days(Random);

                case DataTypeHelper.Boolean:
                    return Random.Next(0, 1) == 1;

                case DataTypeHelper.Decimal:
                    return (decimal)Random.NextDouble() * Random.Next(0, 100);

                case DataTypeHelper.Double:
                    return Random.NextDouble() * Random.Next(0, 100);

                case DataTypeHelper.Money:
                    var moneyMeta = (MoneyAttributeMetadata)_metadata;
                    var min = (int)((moneyMeta.MinValue > int.MinValue ? moneyMeta.MinValue : 0) ?? 0);
                    var max = (int)((moneyMeta.MaxValue < int.MaxValue ? moneyMeta.MinValue : 100000) ?? 100000);

                    var randomSum = Random.Next(min, max);
                    return new Money(randomSum);

                case DataTypeHelper.CurrentUser:
                    var whoAmI = (WhoAmIResponse)service.Execute(new WhoAmIRequest());
                    return new EntityReference("systemuser", whoAmI.UserId);

                case DataTypeHelper.RandomUser:
                    return LookupHelper.GetRandomRecord("systemuser", service, Random).ToEntityReference();

                case DataTypeHelper.Account:
                    return LookupHelper.GetRandomRecord("account", service, Random).ToEntityReference();

                case DataTypeHelper.Contact:
                    return LookupHelper.GetRandomRecord("contact", service, Random).ToEntityReference();

                case DataTypeHelper.Customer:
                    return Random.Next(0, 1) == 1 ?
                        LookupHelper.GetRandomRecord("account", service, Random).ToEntityReference()
                        : LookupHelper.GetRandomRecord("contact", service, Random).ToEntityReference();

                case DataTypeHelper.Country:
                    return RandomStringValue(StringValues.Countries);

                case DataTypeHelper.City:
                    return RandomStringValue(StringValues.Cities);

                case DataTypeHelper.Street:
                    return RandomStringValue(StringValues.Streets);

                case DataTypeHelper.NumberStr:
                    return Random.Next(0, 999999999).ToString();

                case DataTypeHelper.OptionSet:
                    var picklistMeta = (PicklistAttributeMetadata)_metadata;
                    return new OptionSetValue((int)picklistMeta.OptionSet.Options[Random.Next(0, picklistMeta.OptionSet.Options.Count - 1)].Value);

                case DataTypeHelper.Lookup:
                    var lookupMeta = (LookupAttributeMetadata)_metadata;
                    var lookupEntity = lookupMeta.Targets[0];

                    return LookupHelper.GetRandomRecord(lookupEntity, service, Random).ToEntityReference();

                default:
                    return null;

            }

        }

        public void SetTypeOfData(string type)
        {
            TypeOfDataToBeGenerated = type;
        }

        public static implicit operator Attribute(AttributeMetadata metadata)
        {
            return new Attribute(metadata);
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}