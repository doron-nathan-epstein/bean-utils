using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bean.Utils.AspNet.Swashbuckle.OperationFilters.Http
{
  /// <summary>
  /// 
  /// </summary>
  public class HttpDeleteResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var deleteAttribute = context?.MethodInfo?.DeclaringType?.GetCustomAttributes(true)
        .OfType<HttpDeleteAttribute>()
        .FirstOrDefault();

      if (deleteAttribute == null)
      {
        return;
      }

      operation.Responses.Add(
        ((int)HttpStatusCode.NotFound).ToString(),
        new OpenApiResponse { Description = "Not Found" });
      operation.Responses.Add(
        ((int)HttpStatusCode.NotImplemented).ToString(),
        new OpenApiResponse { Description = "Not Implemented" });
    }
  }
}
