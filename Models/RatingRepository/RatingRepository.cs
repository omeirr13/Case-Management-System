namespace Case_Management_System.Models.RatingRepository
{
    public class RatingRepository
    {
        private CmsContext context = new CmsContext();

        public void AddRating(Rating rating)
        {
            context.Ratings.Add(rating);
            context.SaveChanges();
        }

        public List<Rating> GetRatingsOfLawyer(int LawyerId)
        {
            return context.Ratings.Where(l => l.LawyerId == LawyerId).ToList();
        }
    }
}
