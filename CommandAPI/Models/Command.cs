using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage ="{0} out of range, need to have {1} characteres")]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Plataform { get; set; }
    }
}
