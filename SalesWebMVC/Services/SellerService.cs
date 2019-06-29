using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //Método FindAll com implemenação assíncrona para agilizar consultar ao banco
        // O await do return avisa pro compilado que o consulta é assíncrona
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertSellerAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }


        public async Task<Seller> FindSellerByIdAsync(int id)
        {
            //a expressão lâmbida com include permite levar o departamento do vendedor junto com o Id(add using Microsift.EntityFrameworkCore)
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveSellerAsync(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método responsável por atualizar o vendedor
        /// </summary>
        /// <param name="obj"></param>
        public async Task UpdateSellerAsync(Seller obj)
        {
            // o Any verifica se há algum registro no BD com a condição informada
            bool HasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny)
            {
                throw new KeyNotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);//Atualiza o banco
                await _context.SaveChangesAsync();
            }
            //Se ocorrer uma exceção de nível de acesso à dados, a camada de serviço lança uma exceção própria
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}