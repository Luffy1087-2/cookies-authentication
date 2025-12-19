using System.ComponentModel.DataAnnotations.Schema;

namespace cookies_authentication.DB.Tables
{
    [Table("users")]
    public class UsersTable
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("userName")]
        public string? UserName { get; set; }
        [Column("password")]
        public string? Password { get; set; }
    }
}
