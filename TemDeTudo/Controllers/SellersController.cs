using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Data;
using TemDeTudo.Models;
using TemDeTudo.Models.ViewModels;

namespace TemDeTudo.Controllers
{
    public class SellersController : Controller
    {
        private readonly TemDeTudoContext _context;
        
        public SellersController(TemDeTudoContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            //List<Seller> sellers = _context.Seller.ToList();
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }

        public IActionResult Create()
        {
            //Instanciar um SellerFormViewModel
            //Essa instancia vai ter 2 propriedades
            //Um vendedor e uma lista de departamentos
            SellerFormViewModel viewModel = new SellerFormViewModel();
            //Carregando os departamentos do banco de dados
            viewModel.DepartmentList = _context.Department.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            //Testa se foi passado um vendedor
            if (seller == null)
            {
               //Retorna página não encontrada 
               return NotFound();
            }

            //seller.Department = _context.Department.FirstOrDefault();
            //seller.DepartmentId = seller.Department.Id;

            //Adicionar o objeto vendedor ao banco
            _context.Add(seller);
            //Confirma as alterações no bd
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
