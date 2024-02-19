using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace ProxyToggler
{
    public class TaskbarHelper
    {
        public static void PinShortcutToTaskbar(string shortcutPath)
        {
            string pttbPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\pttb.exe";

            if (!File.Exists(pttbPath))
            {
                File.WriteAllBytes(pttbPath, Properties.Resources.pttb);

                ProcessStartInfo inf = new ProcessStartInfo();
                inf.FileName = pttbPath;
                inf.Arguments = "\"" + shortcutPath + "\"";
                inf.WindowStyle = ProcessWindowStyle.Hidden;
                inf.CreateNoWindow = true;

                Process.Start(inf).WaitForExit();

                File.Delete(pttbPath);
            }
            else
            {
                ProcessStartInfo inf = new ProcessStartInfo();
                inf.FileName = pttbPath;
                inf.Arguments = "\"" + shortcutPath + "\"";
                inf.WindowStyle = ProcessWindowStyle.Hidden;
                inf.CreateNoWindow = true;

                Process.Start(inf).WaitForExit();

                File.Delete(pttbPath);
            }
        }

        public static void UnpinShortcutFromTaskbar(string shortcutPath)
        {
            string pttbPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\pttb.exe";

            if (!File.Exists(pttbPath))
            {
                File.WriteAllBytes(pttbPath, Properties.Resources.pttb);

                ProcessStartInfo inf = new ProcessStartInfo();
                inf.FileName = pttbPath;
                inf.Arguments = "-u \"" + shortcutPath + "\"";
                inf.WindowStyle = ProcessWindowStyle.Hidden;
                inf.CreateNoWindow = true;

                Process.Start(inf).WaitForExit();

                File.Delete(pttbPath);
            }
            else
            {

                ProcessStartInfo inf = new ProcessStartInfo();
                inf.FileName = pttbPath;
                inf.Arguments = "-u \"" + shortcutPath + "\"";
                inf.WindowStyle = ProcessWindowStyle.Hidden;
                inf.CreateNoWindow = true;

                Process.Start(inf).WaitForExit();

                File.Delete(pttbPath);
            }
        }
    }

}
