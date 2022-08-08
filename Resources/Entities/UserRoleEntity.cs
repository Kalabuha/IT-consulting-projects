using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;
using Resources.Entities;
using System.ComponentModel.DataAnnotations;

namespace Resources.Entities
{
    [Table("Roles")]
    public class UserRoleEntity : BaseEntity
    {
        [Column("Role_name"), Required, MaxLength(50)]
        public string Name { get; set; } = default!;

        public IList<UserEntity>? Users { get; set; }
    }
}
