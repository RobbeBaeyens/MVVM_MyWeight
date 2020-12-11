using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("DiaryTimeStampMeal", Schema = "MyWeight")]
    public class DiaryTimeStampMeal
    {
        // PK
        public int DiaryTimeStampMealID { get; set; }

        // FK
        public int DiaryTimeStampID { get; set; }
        public int MealID { get; set; }

        // Attributes


        // Nav
        public DiaryTimeStamp DiaryTimeStamp { get; set; }
        public Meal Meal { get; set; }
    }
}
