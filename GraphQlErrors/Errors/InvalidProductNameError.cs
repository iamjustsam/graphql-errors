namespace GraphQlErrors.Errors
{
    public class InvalidProductNameError : IAddProductError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
    }
}
