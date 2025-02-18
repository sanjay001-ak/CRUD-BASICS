﻿using CRUD_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_basic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyUser> MyUsers { get; set; }
    }
}
