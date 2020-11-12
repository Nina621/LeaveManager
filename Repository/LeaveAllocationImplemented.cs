using LeaveManager.Data;
using LeaveManagment.Intarface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Repository
{
    public class LeaveAllocationImplemented : ILeaveAllocation
    {

        ApplicationDbContext _db;


        public LeaveAllocationImplemented(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveAllocation entity)
        {

            _db.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {

            _db.Remove(entity);
            return Save();
        }

      


        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.Update(entity);
            return Save();
        }

        public bool exists(int id)
        {
            return _db.LeaveTypes.Any(q => q.Id == id);
        }

      

         public bool checkAllocation(string EmployeeId, int leaveTypeId)
         {
             var year = DateTime.Now.Year;
             return FindAll().Where(q => q.leaveTypeId == leaveTypeId && q.Year == year && q.EmployeeId == EmployeeId).Any();

        }

        
        public ICollection<LeaveAllocation> getAllocationByEmployee (string id)
        {
            var year = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == id && q.Year == year).ToList();
        }


    }
}
