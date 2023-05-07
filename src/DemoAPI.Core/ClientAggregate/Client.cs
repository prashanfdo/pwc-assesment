using Ardalis.GuardClauses;
using DemoAPI.SharedKernel;
using DemoAPI.SharedKernel.Interfaces;

namespace DemoAPI.Core.ClientAggregate;
public class Client : EntityBase, IAggregateRoot
{
  /// <summary>
  /// Client Name
  /// </summary>
  public string Name { get; private set; }
  /// <summary>
  /// Contact Email Address
  /// </summary>
  public string ContactEmail { get; private set; }
  /// <summary>
  /// Date became customer
  /// </summary>
  public DateTime DateJoinedAsCustomer { get; private set; }

  public Client(string name, string contactEmail, DateTime dateJoinedAsCustomer)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    ContactEmail = Guard.Against.NullOrEmpty(contactEmail, nameof(contactEmail));
    DateJoinedAsCustomer = dateJoinedAsCustomer;
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateContactEmail(string contactEmail)
  {
    ContactEmail = Guard.Against.NullOrEmpty(contactEmail, nameof(contactEmail));
  }

  public void UpdateDateJoinedAsCustomer(DateTime dateJoinedAsCustomer)
  {
    DateJoinedAsCustomer = dateJoinedAsCustomer;
  }
}
