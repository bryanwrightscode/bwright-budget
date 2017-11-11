using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bwright_budget.Models
{
  //Main Tables
  //Household
  public class Household
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; }
    public virtual ICollection<Goal> Goals { get; set; }
  }

  //Goal
  public class Goal
  {
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int HouseholdId { get; set; }

    public virtual Category Category { get; set; }
    public virtual Household Household { get; set; }
  }

  //Bank Account
  public class BankAccount
  {
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public int BankId { get; set; }
    public int HouseholdId { get; set; }
    public int AccountTypeId { get; set; }

    public virtual Bank Bank { get; set; }
    public virtual Household Household { get; set; }
    public virtual AccountType AccountType { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
  }

  //Transaction (for bank accounts)
  public class Transaction
  {
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset Date { get; set; }
    public int BankAccountId { get; set; }
    public int CategoryId { get; set; }

    public virtual BankAccount BankAccount { get; set; }
    public virtual Category Category { get; set; }
  }

  //Lookup Tables
  //Banks
  public class Bank
  {
    public string Id { get; set; }
    public string Name { get; set; }
  }

  //Bank Account Types (eg Checking, debt, savings, investment)
  public class AccountType
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  //Goal/Transaction categories (eg food, housing, entertainment)
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

}