using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("MealRecipe", Schema = "MyWeight")]
    public class MealRecipe
    {
        // PK
        public int MealRecipeID { get; set; }

        // FK
        public int RecipeID { get; set; }
        public int MealID { get; set; }

        // Attributes


        // Nav
        public Recipe Recipe { get; set; }
        public Meal Meal { get; set; }
    }
}