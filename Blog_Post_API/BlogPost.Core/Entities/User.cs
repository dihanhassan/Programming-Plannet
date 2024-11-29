using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Column("Email")]
        [MaxLength(128)]
        public string Email { get; set; }


        [Required]
        [StringLength(256)]
        public string Password { get; set; }

    }
}
