using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProxyToggler
{
    internal class ProxyToggle
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        public static void ToggleProxy()
        {
            _ToggleProxy(!IsProxyEnabled());
        }

        private static void _ToggleProxy(bool enableProxy)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", enableProxy ? 1 : 0);

            if (enableProxy)
            {
                registry.SetValue("ProxyServer", "192.168.49.1:8000");
            }

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to really update
            bool settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            bool refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }


        public static bool IsProxyEnabled()
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            object proxyEnableValue = registry.GetValue("ProxyEnable");
            if (proxyEnableValue != null && int.TryParse(proxyEnableValue.ToString(), out int proxyEnable))
            {
                return proxyEnable == 1;
            }
            return false;
        }

    }
}
