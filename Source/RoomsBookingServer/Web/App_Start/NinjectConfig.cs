using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using Ninject;
using Utility;

namespace Web.App_Start
{
    public static class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<DbContext>().To<DataContext>().InThreadScope();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IMeetingRoomsRepository>().To<MeetingRoomsRepository>();
            kernel.Bind<ICryptoManager>().To<MD5CryptoManager>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IMeetingRoomsService>().To<MeetingRoomsService>();

        }
    }
}