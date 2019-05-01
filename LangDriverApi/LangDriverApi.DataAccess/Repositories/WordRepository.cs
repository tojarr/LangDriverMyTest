using LangDriverApi.Common.Models;
using LangDriverApi.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LangDriverApi.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly LangDriverContext _context;

        public WordRepository(LangDriverContext context)
        {
            _context = context;
        }

        public bool AddWord(Word word)
        {
            _context.Words.Add(word);
            return true;
        }

        public bool DeleteWord(Guid userId, Guid wordId)
        {
            var word = GetWord(userId, wordId);
            if (word != null)
            {
                _context.Words.Remove(word);
                return true;
            }
            return false;
        }

        public Word GetWord(Guid userId, Guid wordId)
        {
            return _context.Words.FirstOrDefault(w => w.Id == wordId && w.UserId == userId);
        }

        public ICollection<Word> GetWords(Guid id)
        {
            var words = _context.Users.Include(w => w.WordsDictionary).FirstOrDefault(u => u.Id == id).WordsDictionary;
            return words;
        }

        public bool UpdateWord(Word word)
        {
            var oldWord = GetWord(word.UserId, word.Id);
            if(oldWord != null)
            {
                oldWord.WordOrigin = word.WordOrigin;
                oldWord.Translate = word.Translate;
                _context.Words.Update(oldWord);
                return true;
            }
            return false;
        }
    }
}
