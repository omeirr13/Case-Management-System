namespace Case_Management_System.Models
{
    public class CaseHistory
    {
        public int Id { get; set; }
        public int? LawyerId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public virtual Lawyer Lawyer { get; set; }
        public virtual User User { get; set; }
    }

}
