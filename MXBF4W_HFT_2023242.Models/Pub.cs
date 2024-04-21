using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Models
{
    public class Pub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; } //primary key
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }

        public int BiggestCustomerId { get; set; } //foreign key

        public virtual Customer Customer { get; set; } // Navigation Property
        public Pub()
        {
                
        }
        public Pub(string line)
        {
            string[] split = line.Split('#');
            PubId = int.Parse(split[0]);
            Name = split[1];
            Address = split[2];
            BiggestCustomerId = int.Parse(split[3]);


        }
    }
}

