using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("Meal", Schema = "MyWeight")]
    public class Meal
    {
        // PK
        public int MealID { get; set; }

        // FK


        // Attributes
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Nav
        public ICollection<DiaryTimeStampMeal> DiaryTimeStampMeals { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }
        public ICollection<MealRecipe> MealRecipes { get; set; }
    }
}
