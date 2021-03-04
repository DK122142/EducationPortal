namespace EducationPortal.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succeeded { get; }

        public string Message { get; }

        public string Property { get; }

        public OperationDetails(bool succeeded, string message, string property)
        {
            this.Succeeded = succeeded;
            this.Message = message;
            this.Property = property;
        }
    }
}
