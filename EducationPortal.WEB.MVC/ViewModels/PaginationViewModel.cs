using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class PaginationViewModel<TModel> where TModel : class
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<TModel> Models { get; set; }
    }
}
