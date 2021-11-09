namespace GraphQlErrors.Errors
{
    public class ProductExistsError : IAddProductError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
    }
}
