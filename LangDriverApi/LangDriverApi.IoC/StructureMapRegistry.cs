using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.BusinesLogic.Managers;
using LangDriverApi.DataAccess.Helpers;
using LangDriverApi.DataAccess.Interfaces;
using LangDriverApi.DataAccess.Repositories;
using Microsoft.AspNetCore.Hosting;
using StructureMap;

namespace LangDriverApi.IoC
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry(IHostingEnvironment environment)
        {
            For<IWordManager>().Use<WordManager>();
            For<IUserManager>().Use<UserManager>();
            For<IWordRepository>().Use<WordRepository>().Ctor<IStorageHelper>();
            For<IUserRepository>().Use<UserRepository>().Ctor<IStorageHelper>();
            For<IStorageHelper>().Use<StorageHelper>().Ctor<IHostingEnvironment>().Is(environment);
            For<IUnitOfWork>().Use<UnitOfWork>();
        }
    }
}
