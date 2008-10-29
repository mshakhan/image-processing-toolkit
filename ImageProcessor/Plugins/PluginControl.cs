using System;
using System.Windows.Forms;

namespace ImageProcessor.Plugins
{
    public enum PluginControlValueType
    {
        String,
        Boolean,
        Double
    }

    public class PluginControl
    {
        private PluginControlValueType valueType;

        private string name;

        public readonly object DefaultValue;

        public PluginControl(PluginControlValueType valueType, string name)
        {
            this.valueType = valueType;
            this.name = name;
            this.DefaultValue = null;
        }

        public PluginControl(PluginControlValueType valueType, string name, object defaultValue) :
            this(valueType, name)
        {
            this.DefaultValue = defaultValue;
        }


        public PluginControlValueType ValueType
        {
            get { return valueType; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
