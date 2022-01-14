using CRUD_Reponsive_Web_API.Entities;
using CRUD_Reponsive_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD_Reponsive_Web_API
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options) {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Document> Documents { get; set; }

    }
}
