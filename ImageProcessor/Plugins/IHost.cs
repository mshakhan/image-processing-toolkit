using System;
using System.Collections.Generic;
using System.Text;

using ImageProcessor.Processing;

namespace ImageProcessor.Plugins
{
    public interface IHost
    {
        Processor Processor { get; }
        WindowManager WindowManager { get; }
    }
}
