using LeaveManager.Data;
using LeaveManagment.Intarface;
using LeaveManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Repository
{
    public class LeaveTypeImplemented : ILeaveType
    {
        ApplicationDbContext _db;
    

        public LeaveTypeImplemented(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveTypeManager entity)
        {
            _db.Add(entity);
            return Save();
        }

  
        public bool Delete(LeaveTypeManager entity)
        {
            _db.Remove(entity);
            return Save();
        }

        public void Edit(LeaveTypeManager leaveTypeEdit)
        {
            throw new NotImplementedException();
        }

        public bool exists(int id)
        {

            return _db.LeaveTypes.Any(q => q.Id == id);
        }

        public ICollection<LeaveTypeManager> FindAll()
        {
            
            return _db.LeaveTypes.ToList();
        }

        public LeaveTypeManager FindById(int id)
        {

            return _db.LeaveTypes.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(LeaveTypeManager entity)
        {
            _db.Update(entity);
            return Save();
        }

      
    }
}
