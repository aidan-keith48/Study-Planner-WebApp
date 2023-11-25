using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using Study_Planner_WebApp.Model;
using System.Collections.ObjectModel;

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
