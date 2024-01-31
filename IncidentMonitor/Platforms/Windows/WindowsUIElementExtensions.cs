using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Platforms.Windows
{
    public static class WindowsUIElementExtensions
    {
        public static void ChangeCursor(this UIElement element)
        {
            Type t = typeof(UIElement);
            var cursor = InputSystemCursor.Create(InputSystemCursorShape.Hand);
            t.InvokeMember("ProtectedCursor",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance,
                null, element,
                new object[] { cursor });
        }
    }
}
