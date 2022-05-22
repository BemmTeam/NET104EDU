
namespace NET104.Entities 
{ 
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category 
    { 
        [Key]
        [Display(Name = "Danh mục ID")]
        public int Category_Id {get;set;} // primary key

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên danh mục")]

        public string Name {get;set;}

    }
}
