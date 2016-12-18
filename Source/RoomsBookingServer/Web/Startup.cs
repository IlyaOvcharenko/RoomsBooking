﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Web.App_Start;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var config = new HttpConfiguration();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
            app.UseNinjectWebApi(config);

            
        }
    }
}
