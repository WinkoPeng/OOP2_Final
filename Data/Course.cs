using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_management_sys.Data
{
    //Creation of the course class
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }

        //Constructor for the course class
        public Course(string courseID, string courseName, string semester) 
        { 
            this.CourseID = courseID;
            this.CourseName = courseName;
            this.Semester = semester;
        }

        //Method to connect to the database and retrieve the course information
        public static List<Course> connect()
        {

            string id;
            string name;
            string semester;
            List<Course> matchingCourses = new List<Course>();
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
                    string sql = "SELECT CourseID, CourseName, Semester FROM coursetable";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader.GetString("CourseID");
                                name = reader.GetString("CourseName");
                                semester = reader.GetString("Semester");
                                matchingCourses.Add(new Course(id, name, semester));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error connecting to the database: {ex.Message}");
                }
                return matchingCourses;
            }
        }
        


        public override string ToString()
        {
            return $"{CourseID}, {CourseName}, {Semester}";
        }

    }
}
