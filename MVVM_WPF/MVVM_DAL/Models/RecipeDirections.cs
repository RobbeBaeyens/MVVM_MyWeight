using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("RecipeDirections", Schema = "MyWeight")]
    public class RecipeDirections
    {
        // PK
        public int RecipeDirectionsID { get; set; }

        // FK
        public int RecipeID { get; set; }

        // Attributes
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        // Nav
        public Recipe Recipe { get; set; }
    }
}
