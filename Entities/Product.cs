
namespace NET104.Entities 
{ 
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product 
    { 
        [Key]
        public int Product_Id {get;set;} // primary key

        [Column(TypeName = "nvarchar(100)")]
        public string Name {get;set;}

        [Column(TypeName = "ntext")]
        public string Desc {get;set;}
        public int Quantity {get; set;}

        public float Price {get;set;} 

        public string Image_Url {get;set;}

        // xác định khóa ngoại
        public int Category_Id {get;set;} 

        [ForeignKey("Category_Id")]
        public Category Category {get;set;}
 
    }
}