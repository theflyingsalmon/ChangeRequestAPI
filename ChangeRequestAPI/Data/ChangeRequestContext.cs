using System;
using Microsoft.EntityFrameworkCore;

namespace ChangeRequestAPI.Data
{
    public class ChangeRequestContext: DbContext
    {
        public DbSet<ChangeRequest> ChangeRequests { get; set; } = null!;

        public ChangeRequestContext(DbContextOptions<ChangeRequestContext> options)
            : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }



    
}
