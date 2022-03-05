using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Bean.Utils.AspNet.Swashbuckle
{
  /// <summary>
  /// Auth.
  /// </summary>
  public class AuthResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// Apply
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var authAttribute =
        context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().FirstOrDefault() ??
        context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AuthorizeAttribute>().FirstOrDefault();

      if (authAttribute == null) return;

      operation.Responses.Add(((int)HttpStatusCode.Unauthorized).ToString(), new OpenApiResponse { Description = "Unauthorized" });
      operation.Responses.Add(((int)HttpStatusCode.Forbidden).ToString(), new OpenApiResponse { Description = "Forbidden" });

      operation.Responses.Extensions.Add("x-allowed-roles", new OpenApiString(authAttribute.Roles));
    }
  }
}
