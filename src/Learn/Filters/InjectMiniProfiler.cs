using System.Web.Http.Description;
using StackExchange.Profiling;
using Swashbuckle.Swagger;

namespace Learn.Filters
{
    public class InjectMiniProfiler:IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.info.contact = new Contact()
            {
                name = MiniProfiler.Current.RenderIncludes().ToHtmlString()
            };
        }
    }
}