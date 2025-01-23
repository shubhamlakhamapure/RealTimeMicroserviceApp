﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Models;

namespace Identity.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
