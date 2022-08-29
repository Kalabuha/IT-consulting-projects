using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("Roles")]
    public class UserRoleEntity : BaseEntity
    {
        [Column("Role_name"), Required, MaxLength(50)]
        public string Name { get; set; } = default!;

        public IList<UserEntity>? Users { get; set; }
    }
}
