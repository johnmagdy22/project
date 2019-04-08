#region Usings

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

#endregion

namespace OnlineShop.StorageHelper
{
    public class LocalStorageHelper
    {
        // function to save image
        // parameters: File, Relative Path, Name
        public static string SaveImage(HttpPostedFileBase file, ImageCategory category, string name)
        {
            // check extension validity
            var extension = Path.GetExtension(file.FileName);

            if (IsValidExtension(extension))
            {
                // compose path and save file
                var path = $"~/Images/{category.ToString()}";
                var finalPath = Path.Combine(path, name + extension).Replace("\\","/");
                var rootPath = HostingEnvironment.MapPath(finalPath);

                file.SaveAs(rootPath);

                return finalPath;
            }


            return "";
        }

        private static bool IsValidExtension(string extension)
        {
            var validExtensions = new string[] {".jpg", ".jpeg", ".png"};
            return validExtensions.Contains(extension.ToLower());
        }

        // function to delete image
        // parameters: Relative Path
    }
}