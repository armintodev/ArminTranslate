using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ArminTranslate.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Translate(string from,string to,string text)
        {
            var client = new RestClient($"https://api.codebazan.ir/lang/google/?FROM=fa&TO=en&TEXT={text}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            ViewBag.Content = response.Content;

            return View();
        }
    }
}
