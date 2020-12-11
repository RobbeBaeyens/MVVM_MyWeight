using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("RecipeCategory", Schema = "MyWeight")]
    public class RecipeCategory
    {
        // PK
        public int RecipeCategoryID { get; set; }

        // FK


        // Attributes
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Nav
        public ICollection<Recipe> Recipes { get; set; }
    }
}
