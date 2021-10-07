using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_OnlyFor_Revice_Perpose.Models
{
    public class TestDTO
    {
        [Key]
        public int ItemCode { get; set; }

        [Required(ErrorMessage = "This is Mandatory")]
        [MaxLength(15)]
        public string ItemName { get; set; }
    }
}
