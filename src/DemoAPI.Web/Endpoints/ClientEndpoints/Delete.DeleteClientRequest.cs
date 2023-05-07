namespace DemoAPI.Web.Endpoints.ClientEndpoints;

public class DeleteClientRequest
{
  public const string Route = "/Clients/{ClientId:int}";
  public static string BuildRoute(int clientId) => Route.Replace("{ClientId:int}", clientId.ToString());

  public int ClientId { get; set; }
}
