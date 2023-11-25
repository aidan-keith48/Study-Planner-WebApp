using System.ComponentModel.DataAnnotations;

namespace Study_Planner_WebApp.Model
{
    public class Module
    {
        public int Id { get; set; }
        public int userID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public double ClassHours { get; set; }
        public int SemesterWeeks { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public double StudyHours { get; set; }
        
    }
}
