using MechatronicsPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MechatronicsPortal.Controllers
{
    public class Util
    {
        public static MechaAlumniEntities getContext()
        {
            return new MechaAlumniEntities();
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}