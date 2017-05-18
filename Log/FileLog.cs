using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Reflection;

namespace TL.Log
{
    public class FileLog
    {
              public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static FileLog()
        {
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public FileLog()
        {
        }
    }
}
