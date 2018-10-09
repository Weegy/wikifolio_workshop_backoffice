using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Umbraco_Wikifolio_Test.OwnCode
{
    public class WikifolioRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var umbracoHelper = new UmbracoHelper(umbracoContext);
            var rootNode = (IPublishedContent) umbracoHelper.ContentAtXPath("//airportRepository").FirstOrDefault();
            var basisNode = rootNode?.Children().FirstOrDefault(x => x.DocumentTypeAlias == "airportInformation");
            var detailNode = rootNode?.Children.FirstOrDefault(x =>
                PublishedContentExtensions.GetPropertyValue<string>(x, "iCAOCode").ToLower() == requestContext.RouteData.Values["id"].ToString().ToLower());
            if (detailNode != null)
            {
                return detailNode;
            }
            return basisNode;
        }
    }
}