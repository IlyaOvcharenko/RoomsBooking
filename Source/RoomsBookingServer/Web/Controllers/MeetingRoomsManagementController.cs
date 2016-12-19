using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Data.Entities;
using Ninject;
using Web.App_Start;
using Web.Models;

namespace Web.Controllers
{
    public class MeetingRoomsManagementController : Controller
    {
        private readonly IMeetingRoomsService _meetingRoomsService;
        public MeetingRoomsManagementController()
        {
            IKernel kernel = NinjectConfig.CreateKernel.Value;
            _meetingRoomsService = kernel.Get<IMeetingRoomsService>();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create room";
            var model = new MeetingRoomEditModel();
            return View("Edit",model);
        }

        [HttpPost]
        public ActionResult Create(MeetingRoomEditModel model)
        {
            ViewBag.Title = "Create room";
            if (ModelState.IsValid)
            {
                var entity = new MeetingRoom();
                model.UpdateBO(entity);
                _meetingRoomsService.Create(entity);
                return RedirectToAction("Index","Home");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit room";
            var entity = _meetingRoomsService.Get(id);
            var model = MeetingRoomEditModel.FromBO(entity);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MeetingRoomEditModel model)
        {
            ViewBag.Title = "Edit room";
            if (!model.Id.HasValue)
            {
                ModelState.AddModelError("", "Not found");
                return View("Edit", model);
            }

            var entity = _meetingRoomsService.Get(model.Id.Value);
            if(entity == null)
                ModelState.AddModelError("", "Not found");

            if (ModelState.IsValid)
            {
                
                model.UpdateBO(entity);
                _meetingRoomsService.Update(entity);
                return RedirectToAction("Index", "Home");
            }
            return View("Edit", model);
        }
    }
}