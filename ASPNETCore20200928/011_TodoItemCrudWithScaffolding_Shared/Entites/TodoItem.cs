namespace _011_TodoItemCrudWithScaffolding_Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TodoItem")]
    public partial class TodoItem
    {
        public long Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public bool IsComplete { get; set; }
    }
}
