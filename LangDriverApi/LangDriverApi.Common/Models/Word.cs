using System;

namespace LangDriverApi.Common.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string WordOrigin { get; set; }
        public string Translate { get; set; }

        public Guid UserId { get; set; }
        //public virtual User User { get; set; }

        public Word()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
