using LangDriver.BusinessLogic.Interfaces;
using LangDriver.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LangDriver.Controllers
{
    [Authorize]
    public class DictionaryController : Controller
    {
        private IDictionaryManager manager;

        //User just for testing, can be remove when that need
        private User user = new User
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };

        public DictionaryController(IDictionaryManager dictionaryManager)
        {
            manager = dictionaryManager;
        }

        [HttpGet]
        public ActionResult GetDictionary()
        {
            var words = manager.GetWords(user.Id);

            return View(words);
        }

        [HttpGet]
        public ActionResult AddWord()
        {
            Word word = new Word();

            return View(word);
        }

        [HttpPost]
        public ActionResult AddWord(Word word)
        {
            manager.AddWord(user.Id, word);

            return RedirectToAction("GetDictionary");
        }

        [HttpGet]
        public ActionResult EditWord(Guid id)
        {
            Word word = manager.GetWordById(user.Id, id);

            return View(word);
        }

        [HttpPost]
        public ActionResult EditWord(Word word)
        {
            manager.EditWord(user.Id, word);

            return RedirectToAction("GetDictionary");
        }

        [HttpGet]
        public ActionResult DeleteWord(Guid id)
        {
            manager.DeleteWord(user.Id, id);

            return RedirectToAction("GetDictionary");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var word = manager.GetWordById(user.Id, id);

            return View(word);
        }

        [HttpGet]
        public ActionResult TrainWords()
        {
            var words = manager.GetWords(user.Id);

            return View(words);
        }
    }
}