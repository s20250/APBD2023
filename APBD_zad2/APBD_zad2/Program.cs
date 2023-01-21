using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace APBD_zad2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var path = @"/Users/magdalena/Documents/GitHub/APBD2023/APBD_zad2/APBD_zad2/";

            using StreamWriter sw = new StreamWriter(Path.Combine(path, "Log.txt"));

            var fileIn = args[0];
            var fileOut = args[1];
            var format = args[2];

            if (!File.Exists(Path.GetFullPath(fileIn)))
            {
                throw new Exception("File not found");
            }
            else
            {
                Console.WriteLine(fileIn);
            }

            try
            {
                using (FileStream fs = File.Create(fileOut)) ;
                Console.WriteLine(Path.GetFullPath(fileOut + "json"));


            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            if (format == "json")
            {
                var lines = File.ReadAllLines(fileIn);
                JArray students = new JArray();
                foreach (var (linesTmp, student) in from string line in lines
                                                    let linesTmp = line
                                                    let student = linesTmp.Split(',')
                                                    select (linesTmp, student))
                {
                    if ((student.Length != 9))
                    {
                        // throw new Exception("Missing data in student file");
                        
                        sw.WriteLine("Missing data in student file " + linesTmp);
                            continue;
                        

                    }

                    if (linesTmp.Split(',').Contains(""))

                    {
                        sw.WriteLine("Missing data in student file " + linesTmp);


                    }

                    if (student.Length == 9)
                    {

                        var newStudent = new JObject(
                            new JProperty("name" + student[0]),
                            new JProperty("surname" + student[1]),
                            new JProperty("studies" + student[2]),
                            new JProperty("studiesMode" + student[3]),
                            new JProperty("index" + student[4]),
                            new JProperty("birthDate" + student[5]),
                            new JProperty("email" + student[6]),
                            new JProperty("motherName" + student[7]),
                            new JProperty("fatherName" + student[8]));

                        if (!students.Contains(newStudent))
                        {
                            students.Add(newStudent);
                        }
                        else
                        {
                            sw.WriteLine("Student already exists in file");
                        }
                        

                    }
                    
                    var jObject = new JObject(
                        new JProperty("university", new JObject(
                            new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                            new JProperty("author", "s20250"),
                            new JProperty("students", students)
                        ))
                    );
                    File.WriteAllText(fileOut, jObject.ToString());
                }
            }


        }


    }
}
