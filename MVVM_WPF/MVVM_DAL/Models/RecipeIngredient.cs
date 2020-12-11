using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("RecipeIngredient", Schema = "MyWeight")]
    public class RecipeIngredient
    {
        // PK
        public int RecipeIngredientID { get; set; }

        // FK
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }

        // Attributes
        [Required]
        public int Amount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Unit { get; set; }

        // Nav
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
