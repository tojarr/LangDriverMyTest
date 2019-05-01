using System.Collections.Generic;

namespace LangDriverApi.DataAccess.Interfaces
{
    public interface IStorageHelper
    {
        IEnumerable<T> LoadData<T>(string fileName) where T:class;
        void SaveData<T>(T data, string fileName) where T : class;
    }
}
