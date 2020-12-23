using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DAL.Models
{
    [Table("Diary", Schema = "MyWeight")]
    public class Diary
    {
        // PK
        public int DiaryID { get; set; }

        // FK
        public int UserID { get; set; }

        // Attributes
        [Required]
        public DateTime Date { get; set; }

        // Nav
        public User User { get; set; }
        public ICollection<DiaryTimeStamp> DiaryTimeStamps { get; set; }
    }
}
