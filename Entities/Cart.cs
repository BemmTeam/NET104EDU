
namespace NET104.Entities 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart 
    { 
        [Key]
        public int Cart_Id {get;set;} // primary key

        public DateTime CreatedDate {get;set;}

        public string User_Id {get;set;}

        [ForeignKey("User_Id")]
        public User User {get; set;} //session - lưu vào trình duyệt - Object CartItem -> Json {"Product" : []}

        public string Items_Json {get;set;} 

        [NotMapped]
        public List<CartItem> Items {get;set;}

    }
}