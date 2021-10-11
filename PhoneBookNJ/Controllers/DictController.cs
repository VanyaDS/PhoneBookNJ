﻿using PhoneRepositoryLibJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookNJ.Controllers
{

    public class DictController : Controller
    {
        IPhoneDictionary<Note> notes = null;
        public DictController(IPhoneDictionary<Note> notes)
        {
            this.notes = notes;
        }
        public ActionResult Index()
        {
            ViewBag.Notes = notes.GetNotes();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(string Surname, string PhoneNumber)
        {
          
            notes.Create(Surname, PhoneNumber);
            ViewBag.Notes = notes.GetNotes();
            return View("Index");
        }
        public ActionResult Update(int id)
        {
            ViewBag.noteId = id;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSave(int id, string surname, string phoneNumber)
        {
           
            notes.Update(id, surname, phoneNumber);
            ViewBag.Notes = notes.GetNotes();
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            ViewBag.noteId = id;
            return View();
        }

        public ActionResult DeleteSave(int id)
        {
          
            notes.Delete(id);
            ViewBag.Notes = notes.GetNotes();
            return View("Index");
        }

    }
}