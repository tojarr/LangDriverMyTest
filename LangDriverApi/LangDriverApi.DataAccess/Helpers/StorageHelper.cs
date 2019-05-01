using LangDriverApi.Common.Utilities;
using LangDriverApi.DataAccess.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;

namespace LangDriverApi.DataAccess.Helpers
{
    public class StorageHelper : IStorageHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private const string UsersPath = "Users";
        private const string DictionariesPath = "Dictionaries";
        private const string UsersFileName = "users.xml";
        private string FullPath { get; set; }

        public StorageHelper(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IEnumerable<T> LoadData<T>(string fileName) where T : class
        {
            MakeDir<T>(fileName);
            return SerializeHelper.LoadData<T>(FullPath);
        }

        public void SaveData<T>(T data, string fileName) where T : class
        {
            MakeDir<T>(fileName);
            SerializeHelper.SaveData(data, FullPath);
        }

        private void MakeDir<T>(string fileName) where T : class
        {
            var mappedPath = Path.Combine(_hostingEnvironment.WebRootPath, fileName == UsersFileName ? UsersPath : DictionariesPath);
            if (!Directory.Exists(mappedPath))
                Directory.CreateDirectory(mappedPath);
            FullPath = $"{mappedPath}/{fileName}";
            if (!File.Exists(FullPath)) SerializeHelper.SaveData(new List<T>(), FullPath);
        }
    }
}
