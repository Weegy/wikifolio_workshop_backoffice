using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Umbraco_Wikifolio_Test.OwnCode
{
    public class WikifolioStartup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            RouteTable.Routes.MapUmbracoRoute(
                "WikifolioCustomRoute",
                "wikifolio/{id}",
                new
                {
                    controller = "Wikifolio",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new WikifolioRouteHandler());
        }

    }

    
}