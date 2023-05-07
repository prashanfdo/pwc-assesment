namespace DemoAPI.Web.Endpoints.ClientEndpoints;

public class ClientListResponse
{
  public List<ClientRecord> Clients { get; set; } = new();
}
