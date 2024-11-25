using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;

namespace Demo.PL.Helper
{
    public static class DocSetting
    {
        public static string UploadFile(IFormFile File , string FolderName)
        {

            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", FolderName);

            string FileName=$"{Guid.NewGuid()}{File.FileName}";

            string FilePath=Path.Combine(FolderPath,FileName);

            using var FS=new FileStream(FilePath, FileMode.Create);
            File.CopyTo(FS);

            return FileName;

        }

        public static void DeleteFile(string FileName,string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",FolderName,FileName);

            if(File.Exists(FilePath)) 
                File.Delete(FilePath);

        }

    }
}
