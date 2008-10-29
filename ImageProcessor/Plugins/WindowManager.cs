using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessor.Plugins
{
    public class WindowManager
    {
        private frmPlugin form = new frmPlugin();
        
        private Dictionary<string, PluginControl> pluginControls = new Dictionary<string, PluginControl>();
		
		private IPlugin plugin;
		
		public WindowManager(IPlugin plugin)
		{
			this.plugin = plugin;
		}

        public void PrepareForm(params PluginControl[] controls)
        {
            form.Width = 250;
            int verticalOffset = 10;
            form.Text = plugin.Name;

            foreach (PluginControl control in controls)
            {
                pluginControls.Add(control.Name, control);

                Control formControl = null;

                switch (control.ValueType)
                {
                    case PluginControlValueType.Boolean:
                        formControl = new CheckBox();
                        break;
                    case PluginControlValueType.String:
                    case PluginControlValueType.Double:
                        formControl = new TextBox();
                        break;
                }

                Label label = new Label();
                label.Text = control.Name;
                label.Left = 10;
                
                formControl.Left = label.Right + 10;
                formControl.Name = control.Name;
                if (control.DefaultValue != null)
                {
                    formControl.Text = control.DefaultValue.ToString();
                }

                label.Top = formControl.Top = verticalOffset;
                verticalOffset += formControl.Height + 10;
                
                form.Controls.Add(label);
                form.Controls.Add(formControl);
            }

            form.Height = verticalOffset + 40;
        }

        public void ShowForm()
        {
            form.ShowDialog();
        }

        public object this[string paramName]
        {
            get
            {
                if (pluginControls.ContainsKey(paramName))
                {
                    PluginControl control = pluginControls[paramName];

                    switch(control.ValueType)
                    {
                        case PluginControlValueType.Boolean:
                            CheckBox cb = (CheckBox)form.Controls[paramName];
                            return cb.Checked;
                        case PluginControlValueType.Double:
                            TextBox dtb = (TextBox)form.Controls[paramName];
                            double value;
                            if (double.TryParse(dtb.Text, out value))
                            {
                                return value;
                            }
                            return null;
                        case PluginControlValueType.String:
                            TextBox stb = (TextBox)form.Controls[paramName];
                            return stb.Text;
                        default:
                            return null;
                    }
                }
                return null;
            }
        }
		
		public void ShowMessage(string message)
		{
			MessageBox.Show(message, string.Format("Image Processor {0} plugin", form.Text));
		}
    }
}
