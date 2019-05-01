using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.Common.Models;
using LangDriverApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LangDriverApi.Controllers
{
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordManager _manager;

        public WordController(IWordManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// GetWords
        /// </summary>
        /// <returns>The words.</returns>
        /// <param name="userId">User identifier.</param>
        [Route("api/{userId}/word")]
        [AcceptVerbs("GET")]
        public IActionResult GetWords(Guid userId)
        {
            var dictionary = _manager.GetWords(userId);
            return dictionary != null
                ? StatusCode(StatusCodes.Status200OK, dictionary)
                : StatusCode(StatusCodes.Status204NoContent, null);
        }

        /// <summary>
        /// GetWord
        /// </summary>
        /// <returns>The word.</returns>
        /// <param name="userId">User identifier.</param>
        /// <param name="id">Identifier.</param>
        [Route("api/{userId}/word/{id}")]
        [AcceptVerbs("GET")]
        public IActionResult GetWord(Guid userId, Guid id)
        {
            var word = _manager.GetWord(userId, id);
            return word != null
                ? StatusCode(StatusCodes.Status200OK, word)
                : StatusCode(StatusCodes.Status404NotFound, null); 
        }

        /// <summary>
        /// AddWord
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="addWord">Add Word Model.</param>
        [Route("api/{userId}/word/")]
        [AcceptVerbs("POST")]
        public IActionResult AddWord(Guid userId, [FromBody] AddWordModel addWord)
        {
            var word = new Word {
                UserId = userId,
                Translate = addWord.Translate,
                WordOrigin = addWord.WordOrigin
            };
            var dictionary = _manager.AddWord(word);
            return dictionary != null
                ? StatusCode(StatusCodes.Status200OK, dictionary)
                : StatusCode(StatusCodes.Status404NotFound, null);
        }

        /// <summary>
        /// UpdateWord
        /// </summary>
        
        /// <param name="word">Word.</param>
        [Route("api/word/")]
        [AcceptVerbs("PUT")]
        public IActionResult UpdateWord([FromBody] Word word)
        {
            var dictionary = _manager.UpdateWord(word);
            return dictionary != null
                ? StatusCode(StatusCodes.Status200OK, dictionary)
                :StatusCode(StatusCodes.Status404NotFound, null);
        }

        /// <summary>
        /// DeleteWord
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="id">Identifier.</param>
        [Route("api/{userId}/word/{id}")]
        [AcceptVerbs("DELETE")]
        public IActionResult DeleteWord(Guid userId, Guid id)
        {
            var dictionary = _manager.DeleteWord(userId, id);
            return dictionary != null
                ? StatusCode(StatusCodes.Status200OK, dictionary)
                : StatusCode(StatusCodes.Status404NotFound, null);
        }
    }
}