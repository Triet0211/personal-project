using SignalRAssignment_SE151127.Models;
using System;

namespace SignalRAssignment_SE151127.ViewModel
{
    public class PostVM
    {
        public int PostId { get; set; }
        public virtual AppUser Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishStatus { get; set; }
        public virtual PostCategory Category { get; set; }
        public bool isLoggingIn { get; set; }
    }
}
