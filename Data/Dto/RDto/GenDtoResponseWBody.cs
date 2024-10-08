namespace ClickedApi.Data.Dto.RDto
{
    public class GenDtoResponseWBody<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
