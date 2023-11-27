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

        //    //This method gets the starting date of the module
        //    public string getStartDate(List<Users> userList)
        //    {
        //        string username = getUserFromList(userList);
        //        string startDate = null;

        //        try
        //        {
        //            newConn.Open();

        //            string query = "SELECT startDate FROM [dbo].[Module] WHERE username = @Username";

        //            using (SqlCommand cmd = new SqlCommand(query, newConn))
        //            {
        //                cmd.Parameters.AddWithValue("@Username", username);
        //                startDate = cmd.ExecuteScalar()?.ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //MessageBox.Show("Error: " + ex.Message);
        //            // Handle the exception (e.g., log it, show an error message)
        //        }
        //        newConn.Close();

        //        return startDate;
        //    }

        //    //Method adds users modules to the databse
        //    public async void addUserModules(studyPlanner_dll.Module module, List<Users> userList)
        //    {
        //        string username = getUserFromList(userList);
        //        string moduleCode = module.ModuleCode;
        //        string moduleName = module.ModuleName;
        //        int credits = module.Credits;
        //        double classHours = module.ClassHours;
        //        int semesterWeeks = module.SemsterWeeks;
        //        string startDate = module.StartDate;
        //        double studyHours = module.StudyHours;

        //        await Task.Run(() =>
        //        {

        //            newConn.Open();

        //            string query = "INSERT INTO Module (username, moduleCode, moduleName, credits, classHours, semesterWeeks, startDate, studyHours)" +
        //                           "VALUES (@Username,@ModuleCode, @ModuleName, @Credits, @ClassHours, @SemsterWeeks, @StartDate, @StudyHours);";

        //            using (SqlCommand cmd = new SqlCommand(query, newConn))
        //            {
        //                cmd.Parameters.AddWithValue("@Username", username);
        //                cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
        //                cmd.Parameters.AddWithValue("@ModuleName", moduleName);
        //                cmd.Parameters.AddWithValue("@Credits", credits);
        //                cmd.Parameters.AddWithValue("@ClassHours", classHours);
        //                cmd.Parameters.AddWithValue("@SemsterWeeks", semesterWeeks);
        //                cmd.Parameters.AddWithValue("@StartDate", startDate);
        //                cmd.Parameters.AddWithValue("@StudyHours", studyHours);

        //                cmd.ExecuteNonQuery();
        //            }
        //            newConn.Close();
        //        });
        //    }

        //    //This method inserts intO Week Tracker
        //    public void AddWeekTracker(List<Users> userlist, string moduleCode, int week, double hours)
        //    {
        //        string currentUser = getUserFromList(userlist);

        //        newConn.Open();

        //        string query = "INSERT INTO Week_Tracker (username, module_Code, Week, Hours) VALUES (@Username, @ModuleCode, @Week, @Hours)";

        //        using (SqlCommand cmd = new SqlCommand(query, newConn))
        //        {
        //            cmd.Parameters.AddWithValue("@Username", currentUser);
        //            cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
        //            cmd.Parameters.AddWithValue("@Week", week);
        //            cmd.Parameters.AddWithValue("@Hours", hours);

        //            cmd.ExecuteNonQuery();
        //        }

        //        newConn.Close();
        //    }

        //    //This method inserts recordData into the databse
        //    public void AddRecords(List<Users> userList, RecordData recordData)
        //    {
        //        string moduleCode = recordData.MCode;
        //        string studyDate = recordData.StudyDate;
        //        double studyHours = recordData.HoursRecorded;
        //        string currentUser = getUserFromList(userList);

        //        newConn.Open();

        //        string Query = "INSERT INTO RecordData (username, moduleCode, studyDate, HoursRecorded) " +
        //                     "VALUES (@Username, @ModuleCode, @StudyDate, @HoursRecorded)";



        //        using (SqlCommand cmd = new SqlCommand(Query, newConn))
        //        {
        //            cmd.Parameters.AddWithValue("@Username", currentUser);
        //            cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
        //            cmd.Parameters.AddWithValue("@StudyDate", studyDate);
        //            cmd.Parameters.AddWithValue("@HoursRecorded", studyHours);

        //            cmd.ExecuteNonQuery();
        //        }
        //        newConn.Close();
        //    }

        //    //This method sets the combo box tohave module code from databse
        //    public ObservableCollection<string> GetModuleCode(List<Users> userList)
        //    {
        //        ObservableCollection<string> Module = new ObservableCollection<string>();
        //        string username = getUserFromList(userList);

        //        newConn.Open();

        //        string query = "SELECT moduleCode FROM [dbo].[Module]" +
        //                       "WHERE username = @Username;";

        //        using (SqlCommand cmd = new SqlCommand(query, newConn))
        //        {
        //            cmd.Parameters.AddWithValue("@Username", username);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    string moduleCode = reader.GetString(0); // Assuming the 'product' column is in the first column (index 0)
        //                    Module.Add(moduleCode);
        //                }
        //            }
        //        }
        //        newConn.Close();
        //        return Module;
        //    }



        //    //This method laods the data for recording hours into the records list
        //    public void LoadDataIntoRecords(List<Users> userList, List<> records)
        //    {
        //        newConn.Open();
        //        string username = getUserFromList(userList);

        //        string query = "SELECT * FROM RecordData WHERE username = @Username";

        //        using (SqlCommand cmd = new SqlCommand(query, newConn))
        //        {
        //            cmd.Parameters.AddWithValue("@Username", username); // Add the username parameter
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    // Extract data from the database
        //                    string moduleCode = reader["moduleCode"].ToString(); // Replace with the actual column name
        //                    double hours = Convert.ToDouble(reader["HoursRecorded"]); // Replace with the actual column name
        //                    string date = reader.GetDateTime(reader.GetOrdinal("studyDate")).ToString("yyyy-MM-dd"); // Replace "studyDate" with the actual column name

        //                    // Create a new RecordData object
        //                    RecordData record = new RecordData(moduleCode, hours, date, 0)
        //                    {
        //                        MCode = moduleCode,
        //                        StudyDate = date,
        //                        HoursRecorded = hours,
        //                        TempVar = 0
        //                    };

        //                    // Add the RecordData object to the records list
        //                    records.Add(record);
        //                }
        //            }
        //        }
        //        newConn.Close();
        //    }

        //    //This method updates the hours from week tracker


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
    

    //public ObservableCollection<string> GetModuleCode(List<RegisterUser> userList)
    //{
    //    ObservableCollection<string> Module = new ObservableCollection<string>();
    //    //string username = getUserFromList(userList);

    //    newConn.Open();

    //    string query = "SELECT moduleCode FROM [dbo].[Module]" +
    //                   "WHERE username = @Username;";

    //    using (SqlCommand cmd = new SqlCommand(query, newConn))
    //    {
    //        cmd.Parameters.AddWithValue("@Username", username);

    //        using (SqlDataReader reader = cmd.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                string moduleCode = reader.GetString(0); // Assuming the 'product' column is in the first column (index 0)
    //                Module.Add(moduleCode);
    //            }
    //        }
    //    }
    //    newConn.Close();
    //    return Module;
    //}
}
}



