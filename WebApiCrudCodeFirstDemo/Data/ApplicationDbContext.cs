using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiCrudCodeFirstDemo.Models;

namespace WebApiCrudCodeFirstDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("WebApiCrudDBConn")
        {}
        public DbSet<Employee> Employees { get; set; }
    }
}