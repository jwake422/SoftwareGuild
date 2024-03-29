﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

		[HttpGet]
        public ActionResult States()
		{
			var model = StateRepository.GetAll();
			return View(model.ToList());
		}

		[HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

		[HttpGet]
		public ActionResult AddState()
		{
			return View(new State());
		}

		[HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

		[HttpPost]
		public ActionResult AddState(State state)
		{
			StateRepository.Add(state);
			return RedirectToAction("States");
		}

		[HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

		public ActionResult EditState(string id)
		{
			var state = StateRepository.Get(id);
			return View(state);
		}

		[HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

		[HttpPost]
		public ActionResult EditState(State state)
		{
			StateRepository.Edit(state);
			return RedirectToAction("States");
		}
		[HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

		[HttpGet]
		public ActionResult DeleteState(string id)
		{
			var state = StateRepository.Get(id);
			return View(state);
		}

		[HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

		[HttpPost]
		public ActionResult DeleteState(State state)
		{
			StateRepository.Delete(state.StateAbbreviation);
			return RedirectToAction("States");
		}
	}
}