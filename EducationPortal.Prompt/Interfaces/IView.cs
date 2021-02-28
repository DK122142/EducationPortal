using System;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Interfaces
{
    public interface IView
    {
        public virtual void View<TModel>(TModel model = null) where TModel : EntityModel
        {
            throw new NotImplementedException($"View is not implemented. Model: {model}");
        }
    }
}
