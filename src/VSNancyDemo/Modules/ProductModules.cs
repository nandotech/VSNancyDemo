using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class ProductModules : NancyModule
    {
        public static int nProductId = 1;
        public static List<Product> lst = new List<Product>();
        public ProductModules() : base("/products")
        {
            Get("/", args => GetProductList());
            Get("/{id:int}", args => GetProductById(args.id));
            Post("/create/{Name}", args =>
            {
                lst.Add(new Product() { Id = nProductId++, Name = args.Name });
                return HttpStatusCode.OK;
            });
        }

        public List<Product> GetProductList()
        {
            lst.Add(new Product() { Id = nProductId++, Name = "Bed" });
            lst.Add(new Product() { Id = nProductId++, Name = "Table" });
            lst.Add(new Product() { Id = nProductId++, Name = "Chair" });
            return lst;
        }

        public Product GetProductById(int Id)
        {
            return lst.Find(item => item.Id == Id);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
