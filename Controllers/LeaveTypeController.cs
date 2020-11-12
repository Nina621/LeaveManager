using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManager.Data;
using LeaveManagment.Intarface;
using LeaveManagment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagment.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveType _repository;
        private readonly IMapper _mapper;

        public LeaveTypeController (ILeaveType repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: LeaveType
        public ActionResult Index( )
        {
            var listLeaveTypes = _repository.FindAll().ToList();
            var model = _mapper.Map<List<LeaveTypeManager>, List<LeaveTypeModel>>(listLeaveTypes);

            return View(model);

        }

        // GET: LeaveType/Details/5
        public ActionResult Details(int id)
        {
            if (!_repository.exists(id))
            {
                return NotFound();
            }

            var leaveTypeDetails =  _repository.FindById(id);
            var model = _mapper.Map<LeaveTypeModel>(leaveTypeDetails);

            return View(model);
     
        }

        // GET: LeaveType/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: LeaveType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeModel typeModel)
        { 
            try
            {
                if (!ModelState.IsValid) {
                    return View(typeModel);
                }

                var leaveTypeCreate = _mapper.Map<LeaveTypeManager>(typeModel);
                bool success = _repository.Create(leaveTypeCreate);

                if (!success) {
                    ModelState.AddModelError("","Error");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveType/Edit/5
        public ActionResult Edit(int id)
        {
            if(!_repository.exists(id))
            {
                return NotFound();
            }

            var leveTypeEdit = _repository.FindById(id);
            var model = _mapper.Map<LeaveTypeModel>(leveTypeEdit);

            return View(model);
        }

        // POST: LeaveType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeModel leaveType)
        {
          
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(leaveType);
                }

                var leaveTypeEdit = _mapper.Map<LeaveTypeManager>(leaveType);
                bool success= _repository.Update(leaveTypeEdit);


                if (!success)
                {
                    ModelState.AddModelError("", "Error");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveType/Delete/5
        public ActionResult Delete(int id)
        {
            var leveTypeDelete = _repository.FindById(id);
            var model = _mapper.Map<LeaveTypeModel>(leveTypeDelete);

            return View(model);

        }

        // POST: LeaveType/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LeaveTypeModel leaveType)
        {
            try
            {
             
               var leaveTypeDelete = _mapper.Map<LeaveTypeManager>(leaveType);
               bool success = _repository.Delete(leaveTypeDelete);


                if (!success)
                {
                    ModelState.AddModelError("", "Error");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}