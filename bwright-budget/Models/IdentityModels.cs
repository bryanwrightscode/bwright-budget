using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace bwright_budget.Models
{
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      return userIdentity;
    }

    //Custom user account properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get { return String.Format("{0} {0}", FirstName, LastName); } }
    public int HouseholdId { get; set; }

    public virtual Household Household { get; set; }
  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("budget-context", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }

    //Database Tables
    public DbSet<Household> Households { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}