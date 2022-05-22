
namespace NET104.Helper 
{
    public class MessageHelper 
    {
        public const string success = "alert alert-success";
        public const string error = "alert alert-danger";

        public string MessageType {get;set;} 

        public string Message {get;set;} 

        public string Icon {get;set;}

        public MessageHelper(string MessageType , string Message) 
        {
            
            this.Message = Message ; 
            this.MessageType = MessageType ;
            
            switch(MessageType) {

                case MessageHelper.success : Icon = "fas fa-check-circle"; break;
                case MessageHelper.error : Icon = "fas fa-times"; break;

            }

        }
    }
}