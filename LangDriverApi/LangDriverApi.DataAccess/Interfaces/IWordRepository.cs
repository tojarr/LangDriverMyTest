using LangDriverApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriverApi.DataAccess.Interfaces
{
    public interface IWordRepository
    {
        ICollection<Word> GetWords(Guid userId);
        Word GetWord(Guid userId, Guid wordId);
        bool AddWord(Word word);
        bool UpdateWord(Word word);
        bool DeleteWord(Guid userId, Guid wordId);
    }
}
