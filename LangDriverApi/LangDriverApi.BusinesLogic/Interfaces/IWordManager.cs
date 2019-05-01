using LangDriverApi.Common.Models;
using System;
using System.Collections.Generic;

namespace LangDriverApi.BusinesLogic.Interfaces
{
    public interface IWordManager
    {
        List<Word> GetWords(Guid userId);
        Word GetWord(Guid userId, Guid wordId);
        List<Word> AddWord(Word word);
        List<Word> UpdateWord(Word word);
        List<Word> DeleteWord(Guid userId, Guid wordId);
    }
}
