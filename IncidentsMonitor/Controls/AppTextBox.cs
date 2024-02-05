using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IncidentMonitor.Controls
{
    public class ExtendedTextBox : TextBox
    {

        [Bindable(true)]
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(ExtendedTextBox), new PropertyMetadata(""));

        //public ExtendedTextBox() : base()
        //{
        //    this.Text
        //}

    }
}
