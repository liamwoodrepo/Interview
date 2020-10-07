using Interview_Web_API.Database.Entity;
using Interview_Web_API.Helpers;
using Interview_Web_API.Models;
using System;
using System.IO;

namespace Interview_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var active = true;

            Console.WriteLine("Please specify the file path for the data.txt file: ");

            while(active)
            {
                var userInput = Console.ReadLine();

                if (userInput.Equals("Done"))
                {
                    active = false;
                }
                else
                {
                    var filename = Path.GetFileName(userInput);

                    if (filename.ToUpper().Equals("DATA.TXT"))
                    {
                        try
                        {
                            var employees = ConvertCSVToEmployee.ConvertCSVFileTOEmployees(userInput);

                            using (var db = new ConnectionString())
                            {
                                foreach (Employee employee in employees)
                                {
                                    db.Add(employee);

                                }
                                db.SaveChanges();
                            }

                            Console.WriteLine("Employees have been added successfully!");
                            Console.WriteLine("Please specify the file path for the next data.txt file or enter 'Done' to exit: ");

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Unable to to process file, please try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to to locate file, please try again!");
                    }
                }
            }
        }
    }
}
