namespace Poetry.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public partial class PoetryContext : DbContext
    {
        public PoetryContext()
            : base("PoetryContext")
        {
        }

        public DbSet<Poet> POET { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
