using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Util
{
    internal class RelativePath
    {
        public static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string projectRoot = System.IO.Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
    }
}
