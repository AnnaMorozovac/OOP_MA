 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance |
                                                BindingFlags.Public | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] fields1;

                switch (input)
                {
                    case "private":
                        fields1 = Array.FindAll(fields, f => f.IsPrivate);
                        break;
                    case "public":
                        fields1 = Array.FindAll(fields, f => f.IsPublic);
                        break;
                    case "protected":
                        fields1 = Array.FindAll(fields, f => f.IsFamily);
                        break;
                    case "all":
                        fields1 = fields;
                        break;
                    default:
                        fields1 = new FieldInfo[0];
                        break;
                }

                foreach (var field in fields1)
                {
                    string access;
                    if (field.IsPublic) access = "public";
                    else if (field.IsFamily) access = "protected";
                    else access = "private";

                    Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
