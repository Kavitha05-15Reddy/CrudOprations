using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOprations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sqlConnection = @"Data Source=RAMANJANEYA\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sqlConnection);
            conn.Open();
            try
            {
                Console.WriteLine("connection establish successfully");
                string answer;
                do
                {
                    Console.WriteLine("Select the option \n 1.Create \n 2.Retrieve \n 3.Update \n 4.Delete");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Create => C    
                            Console.WriteLine("Enter your name:");
                            string stuName = Console.ReadLine();
                            Console.WriteLine("Enter your age:");
                            int stuAge = int.Parse(Console.ReadLine());

                            string insertQuery = "insert into students (stuName,stuAge) values ('" + stuName + "'," + stuAge + ")";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.ExecuteNonQuery();
                            Console.WriteLine("Data inserted succesfully");
                            break;
                        case 2:
                            //Retrieve => R
                            string displayQuery = "select * from students";
                            SqlCommand displayCmd = new SqlCommand(displayQuery, conn);
                            SqlDataReader displayReader = displayCmd.ExecuteReader();
                            while (displayReader.Read())
                            {
                                Console.WriteLine("Id:" + displayReader.GetValue(0).ToString());
                                Console.WriteLine("Name:" + displayReader.GetValue(1).ToString());
                                Console.WriteLine("Age:" + displayReader.GetValue(2).ToString());
                            }
                            displayReader.Close();
                            break;
                        case 3:
                            //Update => U
                            Console.WriteLine("Enter the student id that you would like to upadate");
                            int s_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the age of student to upadate");
                            int s_age = int.Parse(Console.ReadLine());

                            string updateQuery = " update students set stuAge = " + s_age + " where stuId = " + s_id + " ";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                            updateCmd.ExecuteNonQuery();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case 4:
                            //Delete => D
                            Console.WriteLine("Enter the student id that is to be deleted");
                            int st_id = int.Parse(Console.ReadLine());

                            string deleteQuery = "delete from students where stuId = " + st_id;
                            SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                            deleteCmd.ExecuteNonQuery();
                            Console.WriteLine("Data deleted successfully");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    Console.WriteLine("Do you want you continue");
                    answer = Console.ReadLine();
                } while (answer != "No");
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
