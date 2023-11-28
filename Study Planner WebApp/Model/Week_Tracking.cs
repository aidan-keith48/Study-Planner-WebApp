using System.ComponentModel.DataAnnotations;

namespace Study_Planner_WebApp.Model
{
    public class Week_Tracking
    {
        [Key]
        public int Id { get; set; }
        public int userID { get; set; }
        public string moduleCode { get; set; }
        public int weeks { get; set; }
        public double hours { get; set; }
    }
}
