using logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private static Alfabeto_LN alfabeto_LN;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			alfabeto_LN = alfabeto_LN = new Alfabeto_LN();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public IActionResult ProcesarPalabra(string palabra)
		{
			int sumatoriaPalabra = alfabeto_LN.ObtenerSumatoriaLetras(palabra);

			return Json(new { valido = sumatoriaPalabra > 0 ? true : false, Palabra = palabra, Sumatoria = sumatoriaPalabra });
		}
	}
}
