using ABC_OnlyFor_Revice_Perpose.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_OnlyFor_Revice_Perpose.Data
{
    public class TESTContext:DbContext
    {
        public TESTContext()
        {

        }

        public TESTContext(DbContextOptions<TESTContext>options):base (options)
        {

        }

        public DbSet<TestDTO> ABC_Table { get; set; }
    }
}
