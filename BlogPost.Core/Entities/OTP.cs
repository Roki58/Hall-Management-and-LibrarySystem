using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Entities
{
    [Table("OTP", Schema = "dbo")]
    public class OTP : BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

       
        [Column("Email")]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [Column("Code")]
        public int code { get; set; }
    }
}
