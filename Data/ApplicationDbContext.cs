using System;
using System.Collections.Generic;
using System.Text;
using LeaveManager.Data.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagment.Models;

namespace LeaveManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<LeaveTypeManager> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Employees> Employees { get; set; }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void DeleteObjects(LeaveTypeManager leaveType)
        {
            throw new NotImplementedException();
        }

        public DbSet<LeaveManagment.Models.LeaveTypeModel> LeaveTypeModel { get; set; }

        public DbSet<LeaveManagment.Models.CreateRoleModel> CreateRoleModel { get; set; }

      



       



       

    }
}
