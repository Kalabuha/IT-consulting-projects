using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Entities.Base;

namespace Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        [Column("Login"), Required, MaxLength(60)]
        public string Login { get; set; } = default!;


        [Column("Password_hash"), Required, MaxLength(100)]
        public string PasswordHash { get; set; } = default!;


        [Column("Password_salt"), Required, MaxLength(100)]
        public string PasswordSalt { get; set; } = default!;

        [Column("User_role"), Required]
        public int RoleId { get; set; }
        public UserRoleEntity? Role { get; set; }

        public static string CreatePasswordSalt()
        {
            return Guid.NewGuid().ToString("N");
        } 

        public static string CreatePasswordHash(string password, string salt)
        {
            var sha256 = SHA256.Create();
            var saltedPassword = $"{password}:{salt}";
            var buffer = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(buffer);
            var encodedHash = Convert.ToBase64String(hash);
            return encodedHash;
        }
    }
}
