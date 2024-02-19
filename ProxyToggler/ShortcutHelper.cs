using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ProxyToggler
{
    public class ShortcutHelper
    {
        public static string proxyTogglerShortcutPath;
        static string self;
        static ShortcutHelper()
        {
            self = Assembly.GetExecutingAssembly().Location;
            proxyTogglerShortcutPath = ExpandPath(@"%appdata%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\ProxyToggler.lnk");
        }
        public static string ExpandPath(string path)
        {
            // Replace environment variables in the path
            string expandedPath = Environment.ExpandEnvironmentVariables(path);
            return expandedPath;
        }

        public static void InstallShortcut()
        {
            if (!File.Exists(proxyTogglerShortcutPath))
            {
                ShellLink.Shortcut proxyShortcut = ShellLink.Shortcut.CreateShortcut(self);
                proxyShortcut.StringData = new ShellLink.Structures.StringData();
                proxyShortcut.StringData.IconLocation = self;
                int iconId = 1;

                if (ProxyToggle.IsProxyEnabled())
                {
                    iconId = 0;
                }

                proxyShortcut.IconIndex = iconId;

                proxyShortcut.WriteToFile(proxyTogglerShortcutPath);
            }
        }

        public static void SetDisabledIcon()
        {

            if (File.Exists(proxyTogglerShortcutPath))
            {
                TaskbarHelper.UnpinShortcutFromTaskbar(proxyTogglerShortcutPath);
                ShellLink.Shortcut cut = ShellLink.Shortcut.ReadFromFile(proxyTogglerShortcutPath);
                cut.IconIndex = 1;
                cut.WriteToFile(proxyTogglerShortcutPath);
                TaskbarHelper.PinShortcutToTaskbar(proxyTogglerShortcutPath);
            }
        }

        public static void SetEnabledIcon()
        {
            if (File.Exists(proxyTogglerShortcutPath))
            {
                TaskbarHelper.UnpinShortcutFromTaskbar(proxyTogglerShortcutPath);
                ShellLink.Shortcut cut = ShellLink.Shortcut.ReadFromFile(proxyTogglerShortcutPath);
                cut.IconIndex = 0;
                cut.WriteToFile(proxyTogglerShortcutPath);
                TaskbarHelper.PinShortcutToTaskbar(proxyTogglerShortcutPath);
            }
        }
    }
}
