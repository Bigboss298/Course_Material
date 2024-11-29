namespace Course_Material.Model.ResponseModel
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = default!;
        public T Data { get; set; } = default!;
    }
}
