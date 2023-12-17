namespace Case_Management_System.Models.CaseHistoryRepository
{
    public class CaseHistoryRepository
    {
        private CmsContext context = new CmsContext();

        public void AddCase(CaseHistory c)
        {
            context.CaseHistories.Add(c);
            context.SaveChanges();
        }
    }
}
