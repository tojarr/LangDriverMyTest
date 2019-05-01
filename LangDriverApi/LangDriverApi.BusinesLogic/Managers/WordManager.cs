using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.Common.Models;
using LangDriverApi.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LangDriverApi.BusinesLogic.Managers
{
    public class WordManager : IWordManager
    {
        private readonly IUnitOfWork _unit;

        public WordManager(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public List<Word> AddWord(Word word)
        {
            var res = _unit.Words.AddWord( word);
            _unit.Save();
            return res ? GetWords(word.UserId) : null;
        }

        public List<Word> DeleteWord(Guid userId, Guid wordId)
        {
            var res = _unit.Words.DeleteWord(userId, wordId);
            _unit.Save();
            return res ? GetWords(userId) : null;
        }

        public Word GetWord(Guid userId, Guid wordId)
        {
            return _unit.Words.GetWord(userId, wordId);
        }

        public List<Word> GetWords(Guid userId)
        {
            var list = _unit.Words.GetWords(userId).ToList();
            return list;
        }

        public List<Word> UpdateWord(Word word)
        {
            var res = _unit.Words.UpdateWord(word);
            _unit.Save();
            return res ? GetWords(word.UserId) : null;
        }
    }
}
