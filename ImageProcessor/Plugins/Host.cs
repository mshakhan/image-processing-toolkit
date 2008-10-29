using System;
using System.Collections.Generic;
using System.Text;

using ImageProcessor.Processing;

namespace ImageProcessor.Plugins
{
    class Host : IHost
    {
        Processor processor;
        WindowManager windowManager;

        public Host(Processor processor, WindowManager windowManager)
        {
            this.processor = processor;
            this.windowManager = windowManager;
        }

        #region IHost Members

        public Processor Processor
        {
            get { return processor; }
        }

        public WindowManager WindowManager
        {
            get { return windowManager; }
        }

        #endregion
    }
}
