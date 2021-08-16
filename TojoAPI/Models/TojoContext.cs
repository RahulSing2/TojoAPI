using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TojoAPI.Models
{
    public class TojoContext : DbContext
    {
        public TojoContext(DbContextOptions<TojoContext> options)
            : base(options)
        {
        }

        public DbSet<TojoItem> TojoItem { get; set; }
    }
}

