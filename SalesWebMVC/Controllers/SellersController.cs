using SalesWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        public readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Indicar que a ação será um post e não um get
        [HttpPost]
        //Previnir que a aplicação sofra ataque CSRF (dados maliciosos)
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.InsertSeller(seller);
            // redirecionar a requisição para a ação Index, que é ação que mostra a tela principal do crud de vendedores.
            return RedirectToAction(nameof(Index));
        }
    }
}