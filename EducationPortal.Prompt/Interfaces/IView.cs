using System;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Interfaces
{
    public interface IView
    {
        public virtual void View(EntityModel model = default)
        {
            throw new NotImplementedException($"View is not implemented. Model: {model}");
        }
    }
}
