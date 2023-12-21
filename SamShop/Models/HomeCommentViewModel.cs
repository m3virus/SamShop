namespace SamShop.endpoint.Models
{
    public class HomeCommentViewModel
    {
        public int CommentId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
        public HomeCustomerViewModel Customer { get; set; }
    }
}
