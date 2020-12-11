using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("Ingredient", Schema = "MyWeight")]
    public class Ingredient
    {
        // PK
        public int IngredientID { get; set; }

        // FK
        public int NutritionFactID { get; set; }

        // Attributes
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Brand { get; set; }

        // Nav
        public NutritionFact NutritionFact { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
