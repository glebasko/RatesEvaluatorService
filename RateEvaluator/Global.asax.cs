﻿using RateEvaluator.Data;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RateEvaluator
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            LocalDataStorage.Init();
        }
    }
}
