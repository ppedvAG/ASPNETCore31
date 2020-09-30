namespace _011_TodoItemCrudWithScaffolding.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using _011_TodoItemCrudWithScaffolding_Shared;

    public partial class TodoModel : DbContext
    {
        public TodoModel()
            : base("name=TodoModel")
        {
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
