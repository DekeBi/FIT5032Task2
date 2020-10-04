namespace FIT5032Task2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Task2_model : DbContext
    {
        public Task2_model()
            : base("name=Task2_model")
        {
        }

        public virtual DbSet<Tutorials> Tutorials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
