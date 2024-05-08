using HydraApi.Services;
using HydraBusiness.Interfaces;
using HydraBusiness.Repositories;

namespace HydraApi;

public static class ConfigureBusinessService
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped<IBootcampRepository, BootcampRepository>();
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        
        
        services.AddScoped<CandidateService>();
        services.AddScoped<BootcampService>();
        services.AddScoped<CourseService>();
        return services;
    }
}