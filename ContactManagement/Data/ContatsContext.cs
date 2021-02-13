using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Models;

namespace ContactManagement.Data
{
    public class ContatsContext:DbContext
    {
        public ContatsContext(DbContextOptions<ContatsContext> options)
            : base(options)
        {
        }

        public DbSet<ContactsModel> Contacts { get; set; }
    }
}
