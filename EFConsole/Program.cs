using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFConsole
{
    class Program
    {
        public class Emart
        {
            public int ID { get; set; }
            public string Item { get; set; }
            public Decimal Price { get; set; }
        }

        public class EmartDBContext : DbContext
        {
            public DbSet<Emart> Emart { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input");
            Console.WriteLine("");

            using (var context = new EmartDBContext())
            {

                var p = new Emart();
                Console.Write("Item : ");
                p.Item = Console.ReadLine();
                Console.Write("Price : ");
                p.Price =Convert.ToDecimal(Console.ReadLine());

                //    var hasil = context.Emart.Find(2);
                //    hasil.Price = hasil.Price + 1000;
                //    //context.Emart.Remove(hasil);
                context.Emart.Add(p);
                //    context.Entry(hasil).State = EntityState.Deleted;
                context.SaveChanges();
                var hasil1 = from a in context.Emart
                             select a;
                Console.WriteLine("Daftar Barang");
                foreach (var item in hasil1)
                {
                    Console.WriteLine(item.ID + " " + item.Item + " " + item.Price);
                }
            }
            Console.WriteLine("Press Any Key to Exit");
            Console.ReadKey();
        }
        }
}
