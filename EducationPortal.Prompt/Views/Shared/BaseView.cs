using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Views.Shared
{
    public abstract class BaseView
    {
        public abstract void View<TModel>(TModel model = null) where TModel : EntityModel;
    }
}
