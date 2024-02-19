using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyToggler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Install the shortcut if needed
            ShortcutHelper.InstallShortcut();

            if (ProxyToggle.IsProxyEnabled())
            {
                // Disable Proxy
                ProxyToggle.ToggleProxy();
                ShortcutHelper.SetDisabledIcon();
            }
            else
            {
                // Enable Proxy
                ProxyToggle.ToggleProxy();
                ShortcutHelper.SetEnabledIcon();
            }
        }
    }
}
