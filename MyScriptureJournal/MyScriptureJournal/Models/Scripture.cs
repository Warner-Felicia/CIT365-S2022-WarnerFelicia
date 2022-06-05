using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z0-9][a-zA-Z0-9\s]*$")]
        [Required]
        [StringLength(25)]
        public string Book { get; set; }

        [RegularExpression(@"^[0-9\s-]+$")]
        [Required]
        [StringLength(4)]
        public string Chapter { get; set; }

        [RegularExpression(@"^[0-9\s-]+$")]
        [Required]
        [StringLength(20)]
        public string Verse { get; set; }

        [Required]
        [StringLength(300)]
        public string Note { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        
    }
}
