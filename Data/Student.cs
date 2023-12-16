/****************************************************************
 *Name: Congyan Peng, Jubril Somide, Samuel Anowai, Tan Ly
 *date: 12/15/2023
 *Program Description: This is a learning management system app
 *
 ****************************************************************/

using MySqlConnector;
using System;
using System.Collections.Generic;

namespace learning_management_sys.Data
{
    //Creation of the student class
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Semester { get; set; }
        public double GPA { get; set; }
        public string IsGraduated { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }

        //Constructor for the student class
        public Student(string studentID, string studentName, string phoneNumber, string email, string semester, double gpa, string isGraduated, string courseName, string instructorName)
        {
            this.StudentID = studentID;
            this.StudentName = studentName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Semester = semester;
            this.GPA = gpa;
            this.IsGraduated = isGraduated;
            this.CourseName = courseName;
            this.InstructorName = instructorName;
        }

        //Method to connect to the database and retrieve the student information
        public static List<Student> Connect()
        {
            List<Student> students = new List<Student>();
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "schoolmanagement",
                UserID = "root",
                Password = "Congyan20030610*",
            };

            //Connection string to connect to the database
            using (var connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM studenttable";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student(
                                    reader.GetString("StudentID"),
                                    reader.GetString("StudentName"),
                                    reader.GetString("PhoneNumber"),
                                    reader.GetString("Email"),
                                    reader.GetString("Semester"),
                                    reader.GetDouble("GPA"),
                                    reader.GetString("IsGraduated"),
                                    reader.GetString("CourseName"),
                                    reader.GetString("InstructorName")
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error connecting to the database: {ex.Message}");
                }
                return students;
            }
        }

        public override string ToString()
        {
            return $"{StudentID}, {StudentName}, {PhoneNumber}, {Email}, {Semester}, {GPA}, {IsGraduated}, {CourseName}, {InstructorName}";
        }
    }
}
