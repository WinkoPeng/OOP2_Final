using MySqlConnector;
using System;
using System.Collections.Generic;

namespace learning_management_sys.Data
{
    //Creation of the instructor class
    public class Instructor
    {
        public string InstructorID { get; set; }
        public string InstructorName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Semester { get; set; }
        public string IsFullTime { get; set; }
        public double HoursPerMonth { get; set; }
        public double HourWage { get; set; }
        public double Salary { get; set; }
        public string CourseName { get; set; }

        //Constructor for the instructor class
        public Instructor(string instructorID, string instructorName, string phoneNumber, string email, string semester, string isFullTime, double hoursPerMonth, double hourWage, double salary, string courseName)
        {
            this.InstructorID = instructorID;
            this.InstructorName = instructorName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Semester = semester;
            this.IsFullTime = isFullTime;
            this.HoursPerMonth = hoursPerMonth;
            this.HourWage = hourWage;
            this.Salary = salary;
            this.CourseName = courseName;
        }

        //Method to connect to the database and retrieve the instructor information
        public static List<Instructor> Connect()
        {
            List<Instructor> instructors = new List<Instructor>();
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "schoolmanagement",
                UserID = "root",
                Password = "Congyan20030610*",
            };

            using (var connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM instructortable";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                instructors.Add(new Instructor(
                                    reader.GetString("InstructorID"),
                                    reader.GetString("InstructorName"),
                                    reader.GetString("PhoneNumber"),
                                    reader.GetString("Email"),
                                    reader.GetString("Semester"),
                                    reader.GetString("IsFullTime"),
                                    reader.GetDouble("HoursPerMonth"),
                                    reader.GetDouble("HourWage"),
                                    reader.GetDouble("Salary"),
                                    reader.GetString("CourseName")
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error connecting to the database: {ex.Message}");
                }


                return instructors;
            }
        }

        public override string ToString()
        {
            return $"{InstructorID}, {InstructorName}, {PhoneNumber}, {Email}, {Semester}, {IsFullTime}, {HoursPerMonth}, {HourWage}, {Salary}, {CourseName}";
        }
    }
}
