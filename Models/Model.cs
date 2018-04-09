namespace vega.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Make Make { get; set; } // linking to Make.cs
        public int MakeId { get; set; } // foreign key constraint. Refers to same thing as Make - just the index.
    }
}