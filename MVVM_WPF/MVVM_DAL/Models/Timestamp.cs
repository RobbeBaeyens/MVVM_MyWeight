using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_DAL.Models
{
    [Table("Timestamp", Schema = "MyWeight")]
    public class Timestamp
    {
        // PK
        public int TimeStampID { get; set; }

        // FK


        // Attributes
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        // Nav
        public ICollection<DiaryTimeStamp> DiaryTimeStamps { get; set; }
    }
}
