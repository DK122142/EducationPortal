namespace EducationPortal.BLL.Infrastructure
{
    public class ResultDetails<T>
    {
        public bool IsSucceeded { get; }

        public string Message { get; }

        public string Property { get; }

        public T Value { get; }

        public ResultDetails(bool isSucceeded, string message = "", string property = "", T value = default)
        {
            this.IsSucceeded = isSucceeded;
            this.Message = message;
            this.Property = property;
            this.Value = value;
        }
    }
}
