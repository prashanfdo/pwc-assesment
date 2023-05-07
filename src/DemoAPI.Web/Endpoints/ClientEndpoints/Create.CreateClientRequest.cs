using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class CreateClientRequest
{
  public const string Route = "/Clients";

  [Required]
  public string? Name { get; set; }

  [Required]
  public string? ContactEmail { get; set; }

  [Required]
  public DateTime? DateJoinedAsCustomer { get; set; }
}
