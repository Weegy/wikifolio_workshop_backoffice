using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web.WebApi;

namespace Umbraco_Wikifolio_Test.Controller
{
    public class WikifolioTestController : UmbracoApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet, System.Web.Http.HttpOptions]
        public List<ExchangeModel> GetAllBlogItems()
        {
            var blogNodes = (IPublishedContent)Umbraco.ContentAtXPath("//home//blog").FirstOrDefault();
            var resp =  blogNodes.Children<Blogpost>();
            var modifiedList = resp.Select(x => new ExchangeModel(x.Name, x.WriterName)).ToList();
            return modifiedList.ToList();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet, System.Web.Http.HttpOptions]
        public IDictionaryItem GetDictionaryItems(string key)
        {
            var service = Services.MediaService;
            service.
        }
    }
}