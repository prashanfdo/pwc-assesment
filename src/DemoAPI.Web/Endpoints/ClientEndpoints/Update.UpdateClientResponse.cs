namespace DemoAPI.Web.Endpoints.ClientEndpoints;

public class UpdateClientResponse
{
  public UpdateClientResponse(ClientRecord client)
  {
    Client = client;
  }
  public ClientRecord Client { get; set; }
}
