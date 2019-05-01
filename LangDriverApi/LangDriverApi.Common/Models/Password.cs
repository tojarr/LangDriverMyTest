using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriverApi.Common.Models
{
    public class Password
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserPassword { get; set; }

        public virtual User User { get; set; }
    }
}
