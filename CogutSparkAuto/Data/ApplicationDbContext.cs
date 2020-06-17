﻿using System;
using System.Collections.Generic;
using System.Text;
using CogutSparkAuto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CogutSparkAuto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<ServiceShoppingCart> ServiceShoppingCart { get; set; }
        public DbSet<ServiceHeader> ServiceHeader { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }

    }
}
