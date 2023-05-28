using System;

namespace Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.ModelDto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
