namespace Poetry.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PoetryContext : DbContext
    {
        public DbSet<Poet> POET { get; set; }

        public PoetryContext()
            : base("PoetryContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
