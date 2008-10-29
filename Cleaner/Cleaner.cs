using System;
using System.Collections.Generic;
using System.Text;

using ImageProcessor.Plugins;

namespace Cleaner
{
    public class Cleaner : IPlugin
    {
        #region IPlugin Members

        public void Process(IHost host)
        {
            
        }

        public string Name
        {
            get { return "Cleaner"; }
        }

        #endregion
    }
}
