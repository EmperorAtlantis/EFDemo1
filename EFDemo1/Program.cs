using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //KTStoreEntities db = new KTStoreEntities();
            //Console.WriteLine("商品数据项数:{0}\n ", db.Product.Count());
            //IEnumerable<Product> rows = db.Product.Select(x => x);
            //foreach(Product p in rows)
            //{
            //    Console.WriteLine("{2} \t {3}\t\t 定价:{1} \t {0}", p.Name, p.Price, p.Id, p.Category);
            //}
            //Console.Read();
            using (KTStoreEntities kt = new KTStoreEntities())
            {
                //string sql = kt.Product.ToString();
                //Console.WriteLine(sql);
                var state1 = kt.Database.Connection.ConnectionString;
                Console.WriteLine(state1.ToString());
                Product p = kt.Product?.Find(1);
                var state2 = kt.Database.Connection.State;
                Console.WriteLine(JsonConvert.SerializeObject(p));
                Console.WriteLine(state2.ToString());
                DbSet<Product> products = kt.Product;
                //products.Add(new Product() { Id = , Name = "book_xxx", Category = "Book", Price = 56 });
                var state3 = kt.Database.Connection.State;
                Console.WriteLine(state3.ToString());
                //kt.SaveChanges();
                foreach(var p1 in products)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(p1));
                }
            }
            Console.Read();

        }
    }
}
