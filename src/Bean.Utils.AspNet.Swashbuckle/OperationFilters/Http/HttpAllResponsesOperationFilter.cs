using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bean.Utils.AspNet.Swashbuckle.OperationFilters.Http
{
  /// <summary>
  /// 
  /// </summary>
  public class HttpAllResponsesOperationFilter : IOperationFilter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var httpGetResponsesOperationFilter = new HttpGetResponsesOperationFilter();
      httpGetResponsesOperationFilter.Apply(operation, context);

      var httpPostResponsesOperationFilter = new HttpPostResponsesOperationFilter();
      httpPostResponsesOperationFilter.Apply(operation, context);

      var httpPutResponsesOperationFilter = new HttpPutResponsesOperationFilter();
      httpPutResponsesOperationFilter.Apply(operation, context);

      var httpDeleteResponsesOperationFilter = new HttpDeleteResponsesOperationFilter();
      httpDeleteResponsesOperationFilter.Apply(operation, context);

      var httpErrorResponsesOperationFilter = new HttpErrorResponsesOperationFilter();
      httpErrorResponsesOperationFilter.Apply(operation, context);
    }
  }
}
