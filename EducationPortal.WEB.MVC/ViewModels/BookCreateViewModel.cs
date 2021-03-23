namespace EducationPortal.WEB.MVC.ViewModels
{
    public class BookCreateViewModel : MaterialViewModel
    {
        public int PageCount { get; set; }

        public string Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
