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
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? CopiedToPlex { get; set; }
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