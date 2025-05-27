using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.Domain.Entities
{
    [Table("User", Schema = "dbo")]
    //[Index("Email", IsUnique = true, Name = "User_Email")]
    public class User : BaseEntity
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("FirstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        [MaxLength(64)]
        public string LastName { get; set; }


        [Required]
        [Column("HallName")]
        [MaxLength(64)]
        public string HallName { get; set; }


        [Required]
        [Column("StudentId")]
        [MaxLength(64)]
        public string StudentId { get; set; }


        [Required]
        [Column("MobileNumber")]
        [MaxLength(64)]
        public string MobileNumber { get; set; }


        [Required]
        [Column("Email")]
        [MaxLength(128)]
        public string Email { get; set; }


        [Required]
        [StringLength(256)]
        public string Password { get; set; }

    }
}
