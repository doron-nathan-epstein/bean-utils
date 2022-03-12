using System.Net;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bean.Utils.AspNet.Swashbuckle.OperationFilters.Http
{
  /// <summary>
  /// 
  /// </summary>
  public class HttpErrorResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      operation.Responses.Add(
        ((int)HttpStatusCode.InternalServerError).ToString(),
        new OpenApiResponse { Description = "Internal Server Error" });
    }
  }
}
