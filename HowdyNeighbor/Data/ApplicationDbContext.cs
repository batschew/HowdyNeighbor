using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HowdyNeighbor.Models;

namespace HowdyNeighbor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HowdyNeighbor.Models.ChecklistTask> ChecklistTask { get; set; }
        public DbSet<HowdyNeighbor.Models.SearchList> SearchList { get; set; }
    }
}
