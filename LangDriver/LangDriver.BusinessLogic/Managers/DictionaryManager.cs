using LangDriver.BusinessLogic.Interfaces;
using LangDriver.Common.Interfaces;
using LangDriver.Common.Models;
using LangDriver.DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace LangDriver.BusinessLogic.Managers
{
    public class DictionaryManager : IDictionaryManager
    {
        private readonly IDictionaryRepository repo;

        public DictionaryManager(IDictionaryRepository dictionaryRepository)
        {
            repo = dictionaryRepository;
        }

        public List<Word> GetWords(Guid userId)
        {
            return repo.GetWords(userId);
        }

        public void AddWord(Guid userId, Word word)
        {
            repo.AddWord(userId, word);
        }

        public void EditWord(Guid userId, Word newWord)
        {
            repo.EditWord(userId, newWord);
        }

        public void DeleteWord(Guid userId, Guid wordId)
        {
            repo.DeleteWord(userId, wordId);
        }

        public Word GetWordById(Guid userId, Guid wordId)
        {
            return repo.GetWordById(userId, wordId);
        }
    }
}
