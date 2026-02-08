using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS_Fatto.Models;

namespace PS_Fatto.Data
{
    public class PS_FattoContext : DbContext
    {
        public PS_FattoContext (DbContextOptions<PS_FattoContext> options)
            : base(options)
        {
        }

        public DbSet<PS_Fatto.Models.Tarefa> Tarefa { get; set; } = default!;
    }
}
