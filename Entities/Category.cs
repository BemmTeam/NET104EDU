
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
        [Required(ErrorMessage = "{0} là phải nhập")]  // arr = {tendanhmuc, max , min}
        [StringLength(maximumLength: 100, ErrorMessage = "{0} nhập từ {2} đến {1}" , MinimumLength = 3)]

        public string Name {get;set;} 

    }
}
