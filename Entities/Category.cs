
namespace NET104.Entities 
{ 
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category 
    { 
        [Key]
        public int Category_Id {get;set;} // primary key

        [Column(TypeName = "nvarchar(100)")]
        public string Name {get;set;}

    }
}