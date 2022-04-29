using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        //Antes de realizar a migração para o banco de dados por meio do Package Manager Console,
        //é necessário acrescentar na classe Data.SalesWebMVCContext.cs
        //as classes que foram criadas na pasta Models conforme abaixo:
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> Sales { get; set; }
    }
}
