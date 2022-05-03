using System.ComponentModel.DataAnnotations;

namespace E03RepetitionBookValidation.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; } = string.Empty;

        public int? Year { get; set; }

        [Range(1, Int32.MaxValue)]
        public int? Publication { get; set; }

        public override string ToString()
        {
            return $"Title:{Title}, Author: {Author}, ISBN: {ISBN}, Year: {Year}, Publication: {Publication}";
        }
    }
}