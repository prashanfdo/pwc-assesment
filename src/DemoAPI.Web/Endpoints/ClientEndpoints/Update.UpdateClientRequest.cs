using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class UpdateClientRequest
{
  public const string Route = "/Clients";
  [Required]
  public int Id { get; set; }
  public string? Name { get; set; } 
  public string? ContactEmail { get; set; } 
  public DateTime? DateJoinedAsCustomer { get; set; }
}
