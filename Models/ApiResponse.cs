namespace TecnicExam.Models
{
    public class ApiResponse<T>
    {
        public string Ok { get; set; }
        public T Data { get; set; }

        public ApiResponse(string ok, T data)
        {
            Ok = ok;
            Data = data;
        }
    }
}
