using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //Método FindAll com implemenação assíncrona para agilizar consultar ao banco
        // O await do return avisa pro compilado que o consulta é assíncrona
        public async Task<List<Department>> FindAllDepartmentsAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();

        }
    }
}