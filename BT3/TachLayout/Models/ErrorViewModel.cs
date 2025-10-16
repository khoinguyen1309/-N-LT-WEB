namespace TachLayout.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? Message { get; set; }  // thêm thuộc tính này để hiển thị lỗi

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
