#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerSamples.Models;

namespace ControllerSamples.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext (DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<ControllerSamples.Models.Contact> Contact { get; set; }
    }
}
