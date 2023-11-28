using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using Study_Planner_WebApp.Model;
using System.Collections.ObjectModel;
using System.Data;
using studyPlanner_dll;

namespace Study_Planner_WebApp.DbController
{
    public class dbController
    {
        SqlConnection newConn;
        SqlCommand cmd;
        public dbController()
        {
            newConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Study_Planner_WebApp.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        //Mehtod gets the username from list
        //    public string getUserFromList(List<Users> userList)
        //    {
        //        // Initialize the username variable.
        //        string username = "";

        //        // Iterate through the list of Users.
        //        foreach (var item in userList)
        //        {
        //            // Set the username to the value of the current User's Username property.
        //            username = item.Username.ToString();
        //        }

        //        // Return the extracted username.
        //        return username;
        //    }

        //This method gets the starting date of the module
        public string getStartDate(int userID)
        {
            int user = userID;
            string startDate = null;

            try
            {
                newConn.Open();

                string query = "SELECT startDate FROM [dbo].[Module] WHERE userID = @Username";

                using (SqlCommand cmd = new SqlCommand(query, newConn))
                {
                    cmd.Parameters.AddWithValue("@Username", user);
                    startDate = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                // Handle the exception (e.g., log it, show an error message)
            }
            newConn.Close();

            return startDate;
        }


        //This method laods the data for recording hours into the records list
        public List<studyPlanner_dll.RecordData> LoadDataIntoRecords(int userID)
        {
            List<studyPlanner_dll.RecordData> records = new List<studyPlanner_dll.RecordData>();

            newConn.Open();
            //int user = userID;

            string query = "SELECT * FROM RecordData WHERE studentId = @Username";

            using (SqlCommand cmd = new SqlCommand(query, newConn))
            {
                cmd.Parameters.AddWithValue("@Username", userID); // Add the username parameter
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Extract data from the database
                        string moduleCode = reader["mCode"].ToString(); // Replace with the actual column name
                        double hours = Convert.ToDouble(reader["hoursRecorded"]); // Replace with the actual column name
                        string date = reader.GetDateTime(reader.GetOrdinal("studyDate")).ToString("yyyy-MM-dd"); // Replace "studyDate" with the actual column name

                        // Create a new RecordData object
                        studyPlanner_dll.RecordData record = new studyPlanner_dll.RecordData(moduleCode, hours, date, 0)
                        {
                            MCode = moduleCode,
                            StudyDate = date,
                            HoursRecorded = hours,
                            TempVar = 0
                        };

                        // Add the RecordData object to the records list
                        records.Add(record);
                    }
                }
            }
            newConn.Close();
            return records;
        }

        //This method updates the hours from week tracker


        //This method inserts into week information
        public void InsertWeekInformation(int id, string module, int weeks, double hours)
        {
            int userID = id;

            try
            {
                newConn.Open();

                string query = "INSERT INTO Week_Information (userID, moduleCode, Weeks, Hours) " +
                                "VALUES (@Username, @Module, @Weeks, @Hours)";

                using (SqlCommand cmd = new SqlCommand(query, newConn))
                {
                    for (int i = 1; i <= weeks; i++)
                    {
                        cmd.Parameters.AddWithValue("@Username", userID);
                        cmd.Parameters.AddWithValue("@Module", module);
                        cmd.Parameters.AddWithValue("@Weeks", i);
                        cmd.Parameters.AddWithValue("@Hours", hours);

                        cmd.ExecuteNonQuery();

                        // Clear parameters for the next iteration
                        cmd.Parameters.Clear();
                    }
                }
                newConn.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log or display an error message
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        //    }

        //This method loads data from the database into the WeekInfo dictioanry
        public Dictionary<int, double> LoadDataIntoWeekInfo(int userID, string module)
        {
            Dictionary<int, double> weekInfo = new Dictionary<int, double>();

            int usernameID = userID;
            module = "test user: admin";

            try
            {
                newConn.Open(); // Assuming 'newConn' is your SqlConnection object

                string query = "SELECT weeks, hours FROM Week_Information WHERE userID = @Username AND moduleCode = @Module";

                using (SqlCommand cmd = new SqlCommand(query, newConn))
                {
                    cmd.Parameters.AddWithValue("@Username", usernameID);
                    cmd.Parameters.AddWithValue("@Module", module);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int week = reader.GetInt32(0);
                            double hours = reader.GetDouble(1);

                            weekInfo[week] = hours;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                // Handle the exception (e.g., log it, show an error message)
            }
            finally
            {
                newConn.Close(); // Always close the connection, even in case of exceptions
            }

            return weekInfo;
        }
    

    
    }
}



