using DemoAPI.Core.ClientAggregate;
//using DemoAPI.Core.ProjectAggregate;
using DemoAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Web;
public static class SeedData
{
  public static readonly Client Client1 = new("Luke Skywalker", "luke@starwars.com", new(2021, 1, 1));
  public static readonly Client Client2 = new("Han Solo", "han@starwars.com", new(2020, 1, 1)); 

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any Client items.
      if (dbContext.Clients.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Clients)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.Clients.Add(Client1);
    dbContext.Clients.Add(Client2);

    dbContext.SaveChanges();   
  }
}
