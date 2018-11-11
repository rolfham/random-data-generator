using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;

namespace random_data_generator
{
    public static class DataTypeHelper
    {
        public const string Name = "Name";
        public const string FirstName = "First name";
        public const string LastName = "Last name";
        public const string CompanyNames = "Company name";
        public const string Boolean = "Boolean value";
        public const string WholeNumber = "Whole number (wide spread)";
        public const string WholeNumberOneToTen = "Whole number (1-10)";
        public const string WholeNumberPositive = "Pos. number (<100)";
        public const string WholeNumberNegative = "Neg. number (>-100)";
        public const string Street = "Street adress";
        public const string Customer = "Customer (account/contact)";
        public const string Account = "Account";
        public const string Contact = "Contact";
        public const string Lookup = "Lookup";
        public const string Date = "Date & time (any)";
        public const string DateFuture = "Date & time (future)";
        public const string DatePast = "Date & time (past)";
        public const string DatePast30 = "Past 30 days";
        public const string DateFuture30 = "Next 30 days";
        public const string LoremSmall = "Lorem Ipsum (short text)";
        public const string LoremBig = "Lorem Ipsum (long text)";
        public const string Decimal = "Decimal number";
        public const string Money = "Money";
        public const string CurrentUser = "Current user";
        public const string RandomUser = "Random user";
        public const string OptionSet = "Option set value";
        public const string PhoneNumber = "Phone number";
        public const string Email = "Email";
        public const string Age = "Age";
        public const string Double = "Double";
        public const string Country = "Country";
        public const string City = "City";
        public const string NumberStr = "Number";

        public static List<string> GetValidTypes(AttributeTypeCode typeCode)
        {
            var list = new List<string>();
            switch (typeCode)
            {
                case AttributeTypeCode.Integer:
                case AttributeTypeCode.BigInt:
                    list.Add(WholeNumber);
                    list.Add(WholeNumberNegative);
                    list.Add(WholeNumberOneToTen);
                    list.Add(WholeNumberPositive);
                    list.Add(Age);
                    break;

                case AttributeTypeCode.DateTime:
                    list.Add(Date);
                    list.Add(DateFuture);
                    list.Add(DatePast);
                    list.Add(DateFuture30);
                    list.Add(DatePast30);
                    break;

                case AttributeTypeCode.Decimal:
                    list.Add(Decimal);
                    break;

                case AttributeTypeCode.Double:
                    list.Add(Double);
                    list.Add(WholeNumber);
                    list.Add(WholeNumberNegative);
                    list.Add(WholeNumberOneToTen);
                    list.Add(WholeNumberPositive);
                    break;

                case AttributeTypeCode.Owner:
                    list.Add(CurrentUser);
                    list.Add(RandomUser);
                    break;
                case AttributeTypeCode.Money:
                    list.Add(Money);
                    break;

                case AttributeTypeCode.Picklist:
                    list.Add(OptionSet);
                    break;

                case AttributeTypeCode.Lookup:
                    list.Add(Lookup);
                    break;

                case AttributeTypeCode.Customer:
                    list.Add(Customer);
                    list.Add(Contact);
                    list.Add(Account);
                    break;

                case AttributeTypeCode.String:
                    list.Add(LoremSmall);
                    list.Add(LoremBig);
                    list.Add(Name);
                    list.Add(FirstName);
                    list.Add(LastName);
                    list.Add(CompanyNames);
                    list.Add(Email);
                    list.Add(PhoneNumber);
                    list.Add(Country);
                    list.Add(City);
                    list.Add(Street);
                    list.Add(NumberStr);
                    break;

                case AttributeTypeCode.Boolean:
                    list.Add(Boolean);
                    break;
                default:
                    throw new NotImplementedException($"Attributes of type \"{typeCode}\" is not yet supported by this tool :(");
            }

            return list;
        }
    }
}