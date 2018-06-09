using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using generic.mvc.domain.contracts;
using generic.mvc.domain.Entities;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace generic.mvc.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IBaseRepository<User> _userRepository;

        public static async Task crawler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential();
            var listaTitulos = new List<Potro>();
            var url = "http://www.pontoslivelo.com.br/compreepontue/camicado";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("points-info-rectangle")).ToList();

            foreach(var div in divs)
            {
                var potro = new Potro();
                potro.Titulo1 = div.Descendants("div").LastOrDefault(node => node.GetAttributeValue("class", "").Equals("pontos-1")).InnerText;
                potro.Titulo2 = div.Descendants("div").LastOrDefault(node => node.GetAttributeValue("class", "").Equals("pontos-1")).InnerText;
                listaTitulos.Add(potro);
            }

            foreach(var listItem in listaTitulos) 
            {
                System.Console.WriteLine(listItem.Titulo1 + " - " + listItem.Titulo2);
            }
        }

        public HomeController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }        
        public IActionResult Index()
        {
            crawler();
            return View(_userRepository.ListAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
