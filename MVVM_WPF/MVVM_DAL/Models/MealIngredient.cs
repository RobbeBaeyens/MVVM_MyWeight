using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("MealIngredient", Schema = "MyWeight")]
    public class MealIngredient
    {
        // PK
        public int MealIngredientID { get; set; }

        // FK
        public int MealID { get; set; }
        public int IngredientID { get; set; }

        // Attributes


        // Nav
        public Meal Meal { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
