using SalesWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMVC.Services.Exceptions;
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

        public IActionResult DeleteSeller(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindSellerById(id.Value); //Esse .Value é necessário pois o parâmetro id é opcional
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSeller(int id)
        {
            _sellerService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindSellerById(id.Value); //Esse .Value é necessário pois o parâmetro id é opcional
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindSellerById(id.Value); // o .value é necessário quando o parâmetro int? fo opcional
            if (obj == null)
            {
                return NotFound();
            }

            //Instanciar a lista de departamentos para carregar a tela de edição.
            List<Department> departments = _departmentService.FindAllDepartments();
            //Criar o obj viewModel
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellerService.UpdateSeller(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}