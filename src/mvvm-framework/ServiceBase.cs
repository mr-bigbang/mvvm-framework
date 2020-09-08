using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baumann
{
    public abstract class ServiceBase
    {
        protected Logger Log { get; private set; }

        public ServiceBase()
        {
            // See https://github.com/NLog/NLog/wiki/How-to-create-Logger-for-sub-classes
            Log = LogManager.GetLogger(GetType().ToString());
        }
    }
}
