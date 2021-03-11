namespace EducationPortal.BLL.Infrastructure
{
    public class OperationDetails<T> where T : class
    {
        public bool IsSucceeded { get; }

        public string Message { get; }

        public string Property { get; }

        public T Value { get; }

        public OperationDetails(bool isSucceeded, string message = "", string property = "", T value = null)
        {
            this.IsSucceeded = isSucceeded;
            this.Message = message;
            this.Property = property;
            this.Value = value;
        }
    }
}
