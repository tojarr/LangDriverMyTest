using LangDriverApi.Common.Models;
using LangDriverApi.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriverApi.DataAccess.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly LangDriverContext _context;

        public PasswordRepository(LangDriverContext context)
        {
            _context = context;
        }

        public void Create(Password password)
        {
            _context.Add(password);
        }
    }
}
