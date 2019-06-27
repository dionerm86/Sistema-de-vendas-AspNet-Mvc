using SalesWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //Esse método abre o formulário para cadastrar o vendedor
        public IActionResult Create()
        {
            var departments = _departmentService.FindAllDepartments();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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