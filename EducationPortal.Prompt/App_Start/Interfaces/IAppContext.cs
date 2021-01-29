using System;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Interfaces
{
    public interface IAppContext
    {
        IServiceCollection Services { get; set; }

        IServiceProvider ServiceProvider { get; set; }
    }
}
