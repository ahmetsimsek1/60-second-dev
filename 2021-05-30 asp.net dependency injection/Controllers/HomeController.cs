using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2021_05_30_asp.net_dependency_injection.Models;
using Microsoft.AspNetCore.Http;

namespace _2021_05_30_asp.net_dependency_injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameManager _gameManager;
        private readonly CarRepo _carRepo;

        public HomeController(
            ILogger<HomeController> logger,
            IGameManager gameManager,
            CarRepo carRepo)
            => (_logger, _gameManager, _carRepo) = (logger, gameManager, carRepo);

        public IActionResult Index()
        {
            return View(new HomeModel(
                Logger: _logger,
                GameName: _gameManager.GetGameName(),
                CarModel: _carRepo.GetCarModel()
            ));
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
    }
}
