﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Details(int? id)
        {
            // Verifica se foi passado um id como parametro 
            if (id == null)
            {
                return NotFound();
            }

            Seller seller = _context.Seller.Include("Department").FirstOrDefault(x => x.Id == id);

            // Se nao localizou um vendedor com este ID, vai para página de erro
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller seller = _context.Seller
                .Include("Department")
                .FirstOrDefault(x => x.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Seller seller = _context.Seller
                .FirstOrDefault(x => x.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            _context.Remove(seller);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var seller = _context.Seller.First(x => x.Id ==id);

            if (seller == null)
            {
                return NotFound();
            }

            // Cria uma lista de departamentos
            List<Department> departments = _context.Department.ToList();

            // Cria uma instância do viewmodel 
            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Seller = seller;
            viewModel.DepartmentList = departments;
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Edit(Seller seller)
        {
            //_context.Seller.Update(seller);
            _context.Update(seller);
            _context.SaveChanges();
            
            return RedirectToAction("Index");

        }

    }
}
