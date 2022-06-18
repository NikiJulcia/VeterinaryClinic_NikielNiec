using System.Web.Http;
using WebActivatorEx;
using VeterinaryClinic;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace VeterinaryClinic
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "VeterinaryClinicDocumentation");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\VeterinaryClinic.xml", System.AppDomain.CurrentDomain.BaseDirectory));

                    })
                .EnableSwaggerUi(c =>
                    {
                    });

        }
    }
}
