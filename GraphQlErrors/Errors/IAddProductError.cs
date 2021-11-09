namespace GraphQlErrors.Errors
{
    public interface IAddProductError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
    }
}
