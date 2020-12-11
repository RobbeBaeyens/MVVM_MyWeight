using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("Recipe", Schema = "MyWeight")]
    public class Recipe
    {
        // PK
        public int RecipeID { get; set; }

        // FK
        public int RecipeCategoryID { get; set; }

        // Attributes
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Servings { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime PrepTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CookTime { get; set; }

        // Nav
        public ICollection<MealRecipe> MealRecipes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeDirections> RecipeDirections { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
    }
}
