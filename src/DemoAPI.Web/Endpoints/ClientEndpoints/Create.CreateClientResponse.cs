namespace DemoAPI.Web.Endpoints.ClientEndpoints;

public class CreateClientResponse
{
  public CreateClientResponse(int id, string name, string contactEmail, DateTime dateJoinedAsCustomer)
  {
    Id = id;
    Name = name;
    ContactEmail = contactEmail;
    DateJoinedAsCustomer = dateJoinedAsCustomer;
  }
  public int Id { get; set; }
  public string Name { get; set; }
  public string ContactEmail { get; set; }
  public DateTime DateJoinedAsCustomer { get; set; }
}
