using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Data
{
    public class Study_Planner_WebAppContext : DbContext
    {
        public Study_Planner_WebAppContext (DbContextOptions<Study_Planner_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Study_Planner_WebApp.Model.Module> Module { get; set; } = default!;

        public DbSet<Study_Planner_WebApp.Model.RecordData>? RecordData { get; set; }

        public DbSet<Study_Planner_WebApp.Model.RegisterUser>? RegisterUser { get; set; }

        public DbSet<Study_Planner_WebApp.Model.Week_Information>? Week_Information { get; set; }

        public DbSet<Study_Planner_WebApp.Model.Week_Tracking>? Week_Tracking { get; set; }

        


    }
}
