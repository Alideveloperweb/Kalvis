using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{
    public static class Uploder
    {

        #region Uplode

        public static string Uplode(this IFormFile File, string Route)
        {
            if (File != null)
            {
                var Datetime = DateTime.Now;
                string Date = Datetime.Year.ToString() + "-"
                    + Datetime.Month.ToString() + "-"
                    + Datetime.Day.ToString();

                string DefualtPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/" + Route);

                string Filename = Date + "-" + Generator.Generator_Code(3)
                    + Path.GetExtension(File.FileName);

                string ImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/" + Route, Filename);

                if (!Directory.Exists(DefualtPath))
                    Directory.CreateDirectory(DefualtPath);

                using var Stream =
                    new FileStream(ImagePath, FileMode.Create);
                File.CopyTo(Stream);

                return Filename;

            }
            else
            {
                return "";
            }

        }

        #endregion

        #region RemoveFile

        public static void RemoveFile(this string FileName, string Route)
        {
            if (!String.IsNullOrEmpty(FileName))
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/" + Route, FileName);
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }

        }

        #endregion

        #region MoveFile

        public static void MoveFile(string NewRoute, string OldRoute, string FileName)
        {
            string newroute =
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/"
                + NewRoute);

            string oldroute =
             Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/"
             + OldRoute, FileName);

            string PathMove = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/" + NewRoute, FileName);

            if (!Directory.Exists(newroute))
                Directory.CreateDirectory(newroute);

            if (File.Exists(oldroute))
            {
                File.Move(oldroute, PathMove, false);
            }

        }


        #endregion

        #region ChanjeName

        public static void ChanjeName(string OldRoute, string NewRoute)
        {
            string oldroute =
                Path.Combine(Directory.GetCurrentDirectory(),
               "wwwroot/" + OldRoute);

            string newroute =
                     Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/" + NewRoute);

            if (Directory.Exists(oldroute))
            {
                if (Directory.Exists(newroute))
                    Directory.CreateDirectory(newroute);

                Directory.Move(oldroute, newroute);

            }

        }

        #endregion


    }
}
