using LangDriver.Common.Interfaces;
using LangDriver.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LangDriver.DataAccess.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private Dictionary<Guid, List<Word>> userDictionary = new Dictionary<Guid, List<Word>>
        {
            { new Guid("00000000-0000-0000-0000-000000000001"), new List<Word>
            {
                new Word {Id = new Guid("00000000-0000-0000-0000-100000000001"), WordEng = "Cat", WordRus = "Кошка"},
                new Word {Id = new Guid("00000000-0000-0000-0000-100000000002"), WordEng = "Dog", WordRus = "Собака"}
            }},
            { new Guid("00000000-0000-0000-0000-000000000002"), new List<Word>
            {
                new Word {Id = new Guid("00000000-0000-0000-0000-100000000003"), WordEng = "Mouse", WordRus = "Мышка"},
                new Word {Id = new Guid("00000000-0000-0000-0000-100000000004"), WordEng = "Dog", WordRus = "Собака"}
            }}
        };

        public List<Word> GetWords(Guid userId)
        {
            return userDictionary[userId];
        }

        public void AddWord(Guid userId, Word word)
        {
            word.Id = Guid.NewGuid();
            userDictionary[userId].Add(word);
        }

        public void EditWord(Guid userId, Word newWord)
        {
            userDictionary[userId].RemoveAll(item => item.Id == newWord.Id);
            userDictionary[userId].Add(newWord);
        }

        public void DeleteWord(Guid userId, Guid wordId)
        {
            userDictionary[userId].RemoveAll(word => word.Id == wordId);
        }

        public Word GetWordById(Guid userId, Guid wordId)
        {
            return userDictionary[userId].SingleOrDefault(word => word.Id == wordId);
        }
    }
}
