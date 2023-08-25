
namespace Kalvis.Common.Application
{
    public class ApplicationMessage
    {
        public string Message { get; set; }

        public ApplicationMessage(string text)
        {
            Message = text;
        }

        public string Dublicate()
        {
            var message = $"{Message} تکراری است ";
            return message;
        }

        public string ErrorCreate()
        {
            var message = $" {Message}خطا در ایجاد ";
            return message;
        }

        public string ErrorUpdate()
        {
            var message = $" {Message}خطا در بروز رسانی ";
            return message;
        }

        public string ErrorRemove()
        {
            var message = $" {Message}خطا در حذف دسته بندی ";
            return message;
        }

        public string ErrorRestore()
        {
            var message = $" {Message}خطا در بازیابی ";
            return message;
        }

        public string ErrorSave()
        {
            var message = $" {Message}خطا در ذخیره سازی ";
            return message;
        }

        public string Create()
        {
            var message = $" {Message}با موفقیت ایجاد شد  ";
            return message;
        }

        public string Update()
        {
            var message = $" {Message}با موفقیت ویرایش شد  ";
            return message;
        }

        public string Remove()
        {
            var message = $" {Message}با موفقیت حذف شد  ";
            return message;
        }

        public string Restore()
        {
            var message = $" {Message}با موفقیت بازیابی شد  ";
            return message;
        }

        public string NullAbele()
        {
            var message = $" {Message}یافت نشد  ";
            return message;
        }
    }
}
