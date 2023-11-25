using System.ComponentModel.DataAnnotations;

namespace Study_Planner_WebApp.Model
{
    public class RecordData
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public string mCode { get; set; }
        public double hoursRecorded { get; set; }

        [DataType(DataType.Date)]
        public DateTime studyDate { get; set; }
    }
}
