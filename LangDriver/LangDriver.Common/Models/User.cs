using System;
using System.Collections.Generic;

namespace LangDriver.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Dictionary<string , string> Dictionary { get; set; }

        public User()
        {
            Dictionary = new Dictionary<string, string>();
        }
    }
}
