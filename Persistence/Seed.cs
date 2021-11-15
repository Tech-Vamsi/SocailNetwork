using Domain;
namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DBContext context)
        {
            if(context.Activities.Any()) return;
             var activities=new List<Activity> 
             {
                 new Activity{
                     Title="Past Activity",
                     Date=DateTime.Now.AddMonths(-2),
                    Description="Acitivity 2 months ago",
                    Category="Drinks",
                    City="London",
                    Venue="Pub",
                 },
                 new Activity{
                    Title="Past Activity 2",
                    Date=DateTime.Now.AddMonths(-1),
                    Description="Acitivity 1 months ago",
                    Category="Culture",
                    City="Paris",
                    Venue="Louvre",
                 }
             };
             await context.Activities.AddRangeAsync(activities);
             await context.SaveChangesAsync();

        }
    }
}