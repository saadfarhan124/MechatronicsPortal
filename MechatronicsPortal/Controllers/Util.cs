using MechatronicsPortal.Models;
using System;
using System.Collections.Generic;
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
    }
}