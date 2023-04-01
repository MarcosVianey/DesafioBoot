using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth
{
    [Table("auth")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "INT")] public int Id { get; set; }
        [Column("email", TypeName = "VARCHAR(50)"), MaxLength(200), Required]public string Email { get; set; }
        [Column("token", TypeName = "VARCHAR(50)"), MaxLength(200), Required]public string Token { get; set; }
        [Column("username", TypeName = "VARCHAR(50)"), MaxLength(200), Required]public string Username { get; set; }
        [Column("password", TypeName = "VARCHAR(50)"), MaxLength(200), Required]public string Password { get; set; }
    }
    
}