using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bean.Utils.AspNet.Swashbuckle.OperationFilters.Http
{
  /// <summary>
  /// 
  /// </summary>
  public class HttpGetResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var getAttribute = context?.MethodInfo?.DeclaringType?.GetCustomAttributes(true)
        .OfType<HttpGetAttribute>()
        .FirstOrDefault();

      var getSingleItem = context?.ApiDescription
        .ParameterDescriptions.Any() ?? false;

      if (getAttribute == null || !getSingleItem)
      {
        return;
      }

      operation.Responses.Add(
        ((int)HttpStatusCode.NotFound).ToString(),
        new OpenApiResponse { Description = "Not Found" });
    }
  }
}
