using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void InsertSeller(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindSellerById(int id)
        {
            //a expressão lâmbida com include permite levar o departamento do vendedor junto com o Id(add using Microsift.EntityFrameworkCore)
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void RemoveSeller(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método responsável por atualizar o vendedor
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateSeller(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))// o Any verifica se há algum registro no BD com a condição informada
            {
                throw new KeyNotFoundException("Id não encontrado"); 
            }
            try
            {
                _context.Update(obj);//Atualiza o banco 
                _context.SaveChanges();
            }
            //Se ocorrer uma exceção de nível de acesso à dados, a camada de serviço lança uma exceção própria
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
