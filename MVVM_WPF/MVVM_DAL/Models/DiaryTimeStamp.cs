using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("DiaryTimeStamp", Schema = "MyWeight")]
    public class DiaryTimeStamp
    {
        // PK
        public int DiaryTimeStampID { get; set; }

        // FK
        public int DiaryID { get; set; }
        public int TimeStampID { get; set; }

        // Attributes


        // Nav
        public ICollection<DiaryTimeStampMeal> DiaryTimeStampMeals { get; set; }
        public Timestamp Timestamp { get; set; }
        public Diary Diary { get; set; }
    }
}
