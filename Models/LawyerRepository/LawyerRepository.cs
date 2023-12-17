namespace Case_Management_System.Models.LawyerRepository
{
    public class LawyerRepository
	{
		private CmsContext context = new CmsContext();

		public Lawyer GetLawyer(string email)
		{
			return context.Lawyers.FirstOrDefault(l => l.LawyerEmail == email);
		}

		public bool CheckLawyerExists(string email)
		{
			return context.Lawyers.Any(u => u.LawyerEmail == email);
		}
        public Lawyer? GetLawyerOnId(int? id)
        {
            return context.Lawyers.SingleOrDefault(l => l.Id == id);

        }
        public void AddLawyer(Lawyer l)
		{
			context.Lawyers.Add(l);
			context.SaveChanges();
		}

		public List<Lawyer> GetLawyersBasedOnService(Service s)
		{
			return context.Lawyers.Where(l => l.ServiceId == s.Id).ToList();
		}

        //public void RemoveUser(User u)
        //{
        //	context.Users.Remove(u);
        //	context.SaveChanges();
        //}
    }
}
