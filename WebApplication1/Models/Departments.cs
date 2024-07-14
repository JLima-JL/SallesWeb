using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApplication1.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; }=  new List<Seller>() ;

        public Departments() { }

        public Departments(int id, string name)
        {
            Id = id;
            Name = name;
            
        }

        public void AddSeller(Seller s) 
        {
            Sellers.Add(s);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
