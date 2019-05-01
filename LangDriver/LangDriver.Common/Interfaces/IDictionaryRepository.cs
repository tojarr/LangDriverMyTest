using LangDriver.Common.Models;
using System;
using System.Collections.Generic;

namespace LangDriver.Common.Interfaces
{
    public interface IDictionaryRepository
    {
        List<Word> GetWords(Guid userId);
        void AddWord(Guid userId, Word word);
        void EditWord(Guid userId, Word newWord);
        void DeleteWord(Guid userId, Guid wordId);
        Word GetWordById(Guid userId, Guid wordId);
    }
}
