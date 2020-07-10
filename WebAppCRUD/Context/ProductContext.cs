namespace WebAppCRUD.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebAppCRUD.Models;

    public class ProductContext : DbContext
    {
       
        public ProductContext()
            : base("name=ProductContext")
        {

        }

        public DbSet<Product> Products { get; set; }
    }

}