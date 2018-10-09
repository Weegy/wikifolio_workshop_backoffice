using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Umbraco_Wikifolio_Test.OwnCode
{
    public class WikifolioController : Umbraco.Web.Mvc.RenderMvcController
    {
        public  ActionResult Index(RenderModel model, string id)
        {
            var newModel = new AirportDetailModel(model.Content);
            newModel.NewInformationNotFromUmbraco = "WIKIFOLIO TEST";
            var weather = this.LoadWeatherInformation(id);
            newModel.WeatherModel = weather;
            return View("AirportInformation", newModel);
        }

        #region HelperFunction

        protected InformationModel LoadWeatherInformation(string airportCode)
        {
            var restClient = new RestSharp.RestClient("https://api.checkwx.com");
            var restRequest = new RestSharp.RestRequest($"/metar/{airportCode}/decoded");
            restRequest.AddHeader("X-API-Key", "5babb887735bba5bbc7438b455");
            var response = restClient.ExecuteAsGet<InformationModel>(restRequest, "get");
            return response.Data;
        }
        #endregion
    }

    public class AirportDetailModel : RenderModel
    {
        public AirportDetailModel(IPublishedContent content) : base(content) { }

        public string NewInformationNotFromUmbraco { get; set; }
        public InformationModel WeatherModel { get; set; }

       
    }

    public class InformationModel
    {
        public int results { get; set; }
        public List<WeatherModel> data { get; set; }
    }

    public class WeatherModel
    {
        public string name { get; set; }
        public string icao { get; set; }
    }
}