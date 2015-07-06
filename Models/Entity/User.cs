using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangux.com.quikopt.Model
{
    [Table("Users")]
    public class User : AuditableEntity<long>
    {

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(254)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Password { get; set; }


        [MaxLength(1024)]
        public string RecoveryKey { get; set; }

        public bool FlagRecovery { get; set; }

        [Display(Name = "Country")]
        public string CountryIso { get; set; }


    }
}
