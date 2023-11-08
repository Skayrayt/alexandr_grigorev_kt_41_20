using Lab1_alexandr_grigorev_kt_41_20.Interfaces.GradeInterfaces;

namespace Lab1_alexandr_grigorev_kt_41_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
            public static IServiceCollection AddServices(this IServiceCollection services)
            {
                services.AddScoped<IGradeService, GradeService>();
                return services;
            }
    }
}