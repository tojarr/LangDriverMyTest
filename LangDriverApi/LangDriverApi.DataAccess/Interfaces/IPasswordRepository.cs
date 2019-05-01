using LangDriverApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriverApi.DataAccess.Interfaces
{
    public interface IPasswordRepository
    {
        void Create(Password password);
    }
}
