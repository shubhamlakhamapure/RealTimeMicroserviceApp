namespace Product.API.DTO
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; } 

        public Object Result {  get; set; }

        public string Message { get; set; }
    }
}
