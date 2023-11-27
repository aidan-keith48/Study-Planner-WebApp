using Microsoft.AspNetCore.Mvc;
using Study_Planner_WebApp.DbController;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.HelperFunction
{
    public class helperFunction
    {
        public Dictionary<int, double> weekInfo = new Dictionary<int, double>();
        public Dictionary<int, double> testInfo = new Dictionary<int, double>();
        public List<RecordData> records = new List<RecordData>();

        dbController controller = new dbController();



        public void addWeeks(string search, int userID, Dictionary<int, double> weekInfo, Dictionary<int, double> testInfo, List<RecordData> records)
        {
           // Load week-related information for the specified search using the controller.
            weekInfo = controller.LoadDataIntoWeekInfo(userID,search);

            //// Get the start date for the week calculation.
            //string startDateString = controller.getStartDate(userList);

            //// Iterate through the records and calculate week-related information.
            //foreach (var record in records.Where(r => r.studyDate != null && r.mCode == search).ToList())
            //{
            //    // Get the last record with a valid study date for the search.
            //    var lastRecord = records
            //                    .Where(r => r.studyDate != null && r.mCode == search)
            //                    .LastOrDefault();

            //    // Get the last record with non-zero hours recorded for the search.
            //    var lastHours = records
            //                   .Where(r => r.hoursRecorded != 0.0 && r.mCode == search)
            //                   .LastOrDefault();

            //    // Parse the start date and the last study date for week calculation.
            //    DateTime start = DateTime.Parse(startDateString);
            //    DateTime selectedDate = DateTime.Parse(lastRecord.studyDate.ToString());

            //    // Calculate the time difference in weeks.
            //    TimeSpan newDiff = selectedDate - start;
            //    int val = (int)Math.Abs(newDiff.TotalDays / 7);

            //    // Copy week information to testInfo.
            //    testInfo = weekInfo;

            //    // Update week information based on the last record's data.
            //    foreach (KeyValuePair<int, double> item in testInfo)
            //    {
            //        if (item.Key == val)
            //        {
            //            weekInfo[item.Key] = item.Value - lastHours.hoursRecorded;
            //            break;
            //        }
            //    }

            //    // Update the week information in the database using the controller.
            //    foreach (KeyValuePair<int, double> item in weekInfo)
            //    {
            //        if (item.Key == val)
            //        {
            //            controller.AddWeekTracker(userList, search, item.Key, item.Value);
            //            controller.UpdateHours(userList, search, item.Key, item.Value);
            //            break;
            //        }
            //    }
            //    break;
            //}
        }
    }
}
