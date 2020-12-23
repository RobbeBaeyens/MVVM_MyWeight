using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("NutritionFact", Schema = "MyWeight")]
    public class NutritionFact
    {
        // PK
        public int NutritionFactID { get; set; }

        // FK


        // Attributes
        [Required]
        [MaxLength(20)]
        public string Unit { get; set; }

        [Required]
        public decimal Calories { get; set; }

        [Required]
        public decimal Fat { get; set; }

        [Required]
        public decimal Carbohydrates { get; set; }

        [Required]
        public decimal Protein { get; set; }

        // Nav
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
