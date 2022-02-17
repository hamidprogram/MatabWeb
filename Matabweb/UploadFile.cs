namespace Matabweb
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "/assets/images/Blogs/" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }
    }
}
