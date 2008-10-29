using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using ImageProcessor.Processing;

namespace ImageProcessor.Plugins
{
    class PluginManager
    {
        private static Dictionary<string, IPlugin> plugins = new Dictionary<string,IPlugin>();

        public static void LoadPlugins(string path, ToolStripMenuItem menuItem, EventHandler handler)
        {
            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                Assembly asm = Assembly.LoadFile(file);

                foreach (Type type in asm.GetExportedTypes())
                {
                    if (!type.IsAbstract && type.IsClass && type.GetInterface("ImageProcessor.Plugins.IPlugin") != null)
                    {
                        IPlugin plugin = (IPlugin)asm.CreateInstance(type.FullName);
                        plugins.Add(plugin.Name, plugin);
                        
                        ToolStripMenuItem pluginMenuItem = new ToolStripMenuItem();
                        pluginMenuItem.Text = plugin.Name;
                        pluginMenuItem.Tag = plugin.Name;
                        pluginMenuItem.Click += handler;
                        menuItem.DropDownItems.Add(pluginMenuItem);
                    }
                }
            }
        }

        public static void CallPlugin(string name, Processor processor)
        {
			IPlugin plugin = plugins[name];
			WindowManager windowManager = new WindowManager(plugin);
			Host host = new Host(processor, windowManager);
			
			try
			{
				plugin.Process(host);
			}
			catch(Exception e)
			{
				windowManager.ShowMessage(string.Format("{0}\n{1}", 
                    e.Message, e.StackTrace));
			}
        }
    }
}
