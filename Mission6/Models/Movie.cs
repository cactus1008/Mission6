using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } 
        [Required]
        // Throwing in our foreign key info
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        // Make sure minimum year is 1888, the year of the first movie
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
// Everyting in asp.net related to databases is Entity Framework
// Step 1: Set up packages through nuGet
// Step 2: Set up connection String in appsettings.json
// Step 3: Create context file - what communicates between app and DB - Class in Models Folder
// Step 4: Bring in services - in program.cs
//      Configure connection using DbContextfile created
// dotnet tool install --global dotnet-ef
// dotnet ef migrations add Initial