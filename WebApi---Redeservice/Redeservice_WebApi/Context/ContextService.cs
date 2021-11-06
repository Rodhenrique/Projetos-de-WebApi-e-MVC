using Microsoft.EntityFrameworkCore;
using Redeservice_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi.Context
{
    public class ContextService : DbContext
    {
        public ContextService(DbContextOptions<ContextService> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasKey(x => x.id);
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
