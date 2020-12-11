using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DAL.Models
{
    [Table("User", Schema = "MyWeight")]
    public class User
    {
        // PK
        public int UserID { get; set; }

        // FK


        // Attributes
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal WantedWeight { get; set; }

        [Required]
        public int CaloriesDayGoal { get; set; }

        // Nav
        public ICollection<Diary> Diaries { get; set; }
    }
}
