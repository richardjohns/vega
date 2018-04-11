using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("Models")]

    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(255)]

        public Make Make { get; set; } // linking to Make.cs
        public int MakeId { get; set; } // foreign key constraint. Refers to same thing as Make - just the index.
    }
}