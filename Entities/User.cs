
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NET104.Entities
{

    public class User : IdentityUser
    {

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(200)")]

        public string HomeAddress { get; set; }
    }
}