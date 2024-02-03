namespace AirlineCompanyAPI.Dtos.Responses
{
    internal class DefaultJsonResponse<DataType>
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public int InternalCode { get; set; }
        public DataType? Data { get; set; }
    }
}
