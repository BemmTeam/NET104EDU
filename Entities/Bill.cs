
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET104.Entities 

{

    public enum StatusType {

        [Display(Name = "Đơn hàng thành công")]
        Success = 1 , 

        [Display(Name = "Đơn hàng bị hủy")]
        Cancel = 2 ,    

        [Display(Name = "Đơn hàng đang giao")]
        Pending = 3 
    }
    public class Bill 
    {   
        [Key]
        public int Bill_Id {get;set;}

        public StatusType Status {get;set;}

        public DateTime CreatedDate {get;set;}

       [Column(TypeName = "nvarchar(200)")]
        public string Address {get;set;}

        public float Total {get;set;}

        public int Cart_Id {get;set;}
        [ForeignKey("Cart_Id")]
        public Cart Cart {get;set;}

        public string User_Id {get;set;}

        [ForeignKey("User_Id")]
        public User User {get;set;}
    }
    
}