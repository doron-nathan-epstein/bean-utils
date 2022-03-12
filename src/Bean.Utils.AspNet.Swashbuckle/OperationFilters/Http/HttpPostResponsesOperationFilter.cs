using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bean.Utils.AspNet.Swashbuckle.OperationFilters.Http
{
  /// <summary>
  /// 
  /// </summary>
  public class HttpPostResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var postAttribute = context?.MethodInfo?.DeclaringType?.GetCustomAttributes(true)
        .OfType<HttpPostAttribute>()
        .FirstOrDefault();

      if (postAttribute == null)
      {
        return;
      }

      operation.Responses.Add(
        ((int)HttpStatusCode.BadRequest).ToString(),
        new OpenApiResponse { Description = "Bad Request" });
    }
  }
}
