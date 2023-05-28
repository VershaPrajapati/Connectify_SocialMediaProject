namespace FollowMicroservice.DataAccessLayer.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public string Follower { get; set; }
        public string Following { get; set; }
        // Add any additional properties here
    }
}
