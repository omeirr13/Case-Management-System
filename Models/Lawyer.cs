namespace Case_Management_System.Models
{
        public class Lawyer
        {
            public int Id { get; set; }
            public string LawyerName { get; set; }
            public string LawyerEmail { get; set; }
            public string LawyerPassword { get; set; }
            public int? ServiceId { get; set; }
            public double? Rate { get; set; }

            public virtual ICollection<CaseHistory> CaseHistories { get; set; } = new List<CaseHistory>();
            public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
            public virtual Service Service { get; set; }
        }
}
