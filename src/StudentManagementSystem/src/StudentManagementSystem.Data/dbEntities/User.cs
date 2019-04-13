using EFCore.GenericRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Data.DbEntities
{
    public class User : SoftDeletableDbEntity
    {
        public int FKPersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        [ForeignKey("FKPersonID")]
        public virtual Person Person { get; set; }
    }
}
