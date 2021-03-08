using System;
using System.Threading.Tasks;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            new Start();
        }
    }
}
