using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessor.Plugins
{
    public interface IPlugin
    {
        void Process(IHost host);
        string Name { get; }
    }
}
