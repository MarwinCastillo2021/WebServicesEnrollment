using SoapCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebServicesEnrollment.Services;

namespace WebServiceEnrollment
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IEnrollmentService, EnrollmentService>();
            services.AddMvc();
            services.AddSoapCore();
        } 
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSoapEndpoint<IEnrollmentService>("/EnrollmentService.asxm", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
        }      
     }
}