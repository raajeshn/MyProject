using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace JSONToListComparisonApp
{
    class ContractDetails
    {
        public List<string> models { get; set; }
        public List<string> qualifiedCategories { get; set; }
        public List<string> nonQualifiedCategories { get; set; }
    }

    class Program
    {
        static Dictionary<string, List<ContractDetails>> storedData;

        static void Main(string[] args)
        {
            storedData = LoadDataFromJSON();

            // Simulate a change in the JSON value
            string modifiedJsonData = @"
            {
                ""contracts"": [
                    {
                        ""models"": [
                            ""All""
                        ],
                        ""qualifiedCategories"": [
                            ""SW error"",
                            ""SW Qualified"",
                            ""Job SW Freeze"",
                            ""Recipe Editor Freeze"",
                            ""SW Failure"",
                            ""HW Qualified"",
                            ""HW Failure"",
                            ""Failed Daily PM"",
                            ""Daily PM SW Freeze"",
                            ""Daily PM Freeze or Failure"",
                            ""Daily PM Failure or Freeze"",
                            ""HW error"",
                            ""Tool failure"",
                            ""Tool Failure"",
                            ""Tool hang-up""
                        ],
                        ""nonQualifiedCategories"": [
                            ""Testing"",
                            ""Engineering"",
                            ""HW Non-Qualified"",
                            ""KLA Preventative Maintence"",
                            ""Long Local Run"",
                            ""Other"",
                            ""Planned Restart"",
                            ""Repair"",
                            ""PM"",
                            ""PM Freeze or Failure"",
                            ""Schedule restart"",
                            ""Scheduled Reset"",
                            ""SW Non-Qualified"",
                            ""SW Upgrade"",
                            ""HW Upgrade"" 
                        ]
                    }
                ]
            }";

            var modifiedData = DeserializeJSON(modifiedJsonData);

            CompareAndDisplayModifiedData(modifiedData);
        }

        static Dictionary<string, List<ContractDetails>> LoadDataFromJSON()
        {
            string jsonData = @"
            {
                ""contracts"": [
                    {
                        ""models"": [
                            ""All""
                        ],
                        ""qualifiedCategories"": [
                            ""SW error"",
                            ""SW Qualified"",
                            ""Job SW Freeze"",
                            ""Recipe Editor Freeze"",
                            ""SW Failure"",
                            ""HW Qualified"",
                            ""HW Failure"",
                            ""Failed Daily PM"",
                            ""Daily PM SW Freeze"",
                            ""Daily PM Freeze or Failure"",
                            ""Daily PM Failure or Freeze"",
                            ""HW error"",
                            ""Tool failure"",
                            ""Tool Failure"",
                            ""Tool hang-up""
                        ],
                        ""nonQualifiedCategories"": [
                            ""Testing"",
                            ""Engineering"",
                            ""HW Non-Qualified"",
                            ""KLA Preventative Maintence"",
                            ""Long Local Run"",
                            ""Other"",
                            ""Planned Restart"",
                            ""Repair"",
                            ""PM"",
                            ""PM Freeze or Failure"",
                            ""Schedule restart"",
                            ""Scheduled Reset"",
                            ""SW Non-Qualified"",
                            ""SW Upgrade"",
                            ""HW Upgrade""
                        ]
                    }
                ]
            }";

            return DeserializeJSON(jsonData);
        }

        static Dictionary<string, List<ContractDetails>> DeserializeJSON(string jsonData)
        {
            return JsonSerializer.Deserialize<Dictionary<string, List<ContractDetails>>>(jsonData);
        }

        static void CompareAndDisplayModifiedData(Dictionary<string, List<ContractDetails>> newData)
        {
            foreach (var newContract in newData["contracts"])
            {
                var storedContract = storedData["contracts"].FirstOrDefault();

                if (storedContract != null)
                {
                    if (!newContract.qualifiedCategories.SequenceEqual(storedContract.qualifiedCategories))
                    {
                        Console.WriteLine("Qualified Categories Modified:");
                        foreach (var category in newContract.qualifiedCategories)
                        {
                            Console.WriteLine(category);
                        }
                    }

                    if (!newContract.nonQualifiedCategories.SequenceEqual(storedContract.nonQualifiedCategories))
                    {
                        Console.WriteLine("Non-Qualified Categories Modified:");
                        foreach (var category in newContract.nonQualifiedCategories)
                        {
                            Console.WriteLine(category);
                        }
                    }
                }
            }
        }
    }
}
