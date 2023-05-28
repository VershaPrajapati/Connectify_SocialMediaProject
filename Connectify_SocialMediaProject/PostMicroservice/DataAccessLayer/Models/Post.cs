using System;

namespace Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }

        //public virtual Connectify_SocialMediaProject.UserManagementMicroservice.DataAccessLayer.Models.User User { get; set; }
    }
}
