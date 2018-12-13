using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTAPI.DAL.EF;
using RESTAPI.Services.BLL;
using RESTAPI.Services.Interfaces;
using SimpleInjector;

namespace DependensyResolver
{
    using RESTAPI.DAL;
    using RESTAPI.DAL.Interfaces;

    public static class Resolver
    {
        public static void Resolve(Container container)
        {
                container.Register<UserContext>();
                container.Register<IUserRepository, UserRepository>();
                container.Register<IUserService, UserService>();
        }
    }
}
