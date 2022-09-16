using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Controllers
{
    public struct ClsReturn
    {
        public string action { get; set; }
        public DataTable data { get; set; }
    }
}