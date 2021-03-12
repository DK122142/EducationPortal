namespace EducationPortal.WEB.MVC.ViewModels
{
    public class BookViewModel : MaterialViewModel
    {
        public int PageCount { get; set; }

        public string Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
