namespace EducationPortal.BLL.Infrastructure
{
    public class ResultDetails
    {
        public bool IsSucceeded { get; }

        public string Message { get; }

        public string Property { get; }

        public ResultDetails(bool isSucceeded, string message = "", string property = "")
        {
            this.IsSucceeded = isSucceeded;
            this.Message = message;
            this.Property = property;
        }
    }
}
