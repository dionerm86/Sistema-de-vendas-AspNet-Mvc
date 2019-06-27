using System.Collections.Generic;

namespace SalesWebMVC.Models.ViewModels
{
    public class SellerFormViewModel //Essa classe contém os dados para o cad de vendedor
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
