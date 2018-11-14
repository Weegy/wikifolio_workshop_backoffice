using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco_Wikifolio_Test.Controller
{
    public class ExchangeModel
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public ExchangeModel(string name, string author)
        {
            this.Name = name;
            this.Author = author;
        }
    }
}