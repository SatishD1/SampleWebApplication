using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.IO;
using System.Net;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public List<string> ReadConfig()
		{
			//Creating a Folder
			string root = @"C:\Test";
			if (!Directory.Exists(root))
			{
				Directory.CreateDirectory(root);
			}

			//Download file
			//WebClient client = new WebClient();
			//client.DownloadFile(@"https://www.dropbox.com/s/qmusxckwvtxvs60/EnvionmentConfiguration.txt?dl=1", @"C:\Test\EnvionmentConfiguration.txt");

			// Read the file as one string.
			string text = System.IO.File.ReadAllText(@"C:\Test\EnvionmentConfiguration.txt");
			string[] ResultArr = text.Split(';');
			string[] EnvironmentArr = ResultArr[0].Split(':');
			string Environemnt = EnvironmentArr[1];
			string Learnmore1 = null;
			string Learnmore2 = null;
			string Learnmore3 = null;
			foreach (string a in ResultArr)
			{
				if (a.Contains(Environemnt + ":"))
				{
					string[] urlarr = a.Split(',');
					foreach (string b in urlarr)
					{
						if (b.Contains("Learn more 1"))
						{
							string[] Suburlarr = b.Split('=');
							Learnmore1 = Suburlarr[1].Trim();
						}
						else if (b.Contains("Learn more 2"))
						{
							string[] Suburlarr = b.Split('=');
							Learnmore2 = Suburlarr[1].Trim();
						}
						else if (b.Contains("Learn more 3"))
						{
							string[] Suburlarr = b.Split('=');
							Learnmore3 = Suburlarr[1].Trim();
						}
					}
				}
			}
			List<string> result = new List<string>();
			result.Add(Learnmore1);
			result.Add(Learnmore2);
			result.Add(Learnmore3);
			return result;
		}

	}
}
