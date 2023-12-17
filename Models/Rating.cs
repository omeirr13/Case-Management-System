namespace Case_Management_System.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string RatingText { get; set; }
        public int? Rating1 { get; set; }
        public int? LawyerId { get; set; }
        public int? UserId { get; set; }

        public virtual Lawyer Lawyer { get; set; }
        public virtual User User { get; set; }
    }
}
