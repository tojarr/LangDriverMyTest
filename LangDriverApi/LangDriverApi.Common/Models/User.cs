using System;
using System.Collections;
using System.Collections.Generic;

namespace LangDriverApi.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool InActive { get; set; }
        
        public virtual ICollection<Word> WordsDictionary { get; set; }

        public User()
        {
            WordsDictionary = new List<Word>();
        }
    }
}
