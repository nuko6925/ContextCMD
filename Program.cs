using Microsoft.Win32;

namespace ContextCMD
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string arg = args[0];
            string verb = "ContextCMD";
            if (arg.Equals("install"))
            {
                string cl = "cmd";
                string desc = "コマンドプロンプトを開く";
                // Folder
                RegistryKey cmdKey = Registry.ClassesRoot.CreateSubKey("Folder\\shell\\" + verb + "\\command");
                cmdKey.SetValue("", cl);
                cmdKey.Close();
                RegistryKey verbKey = Registry.ClassesRoot.CreateSubKey("Folder\\shell\\" + verb);
                verbKey.SetValue("", desc);
                verbKey.Close();
                // Directory - Bg
                cmdKey = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\shell\\" + verb + "\\command");
                cmdKey.SetValue("", cl);
                cmdKey.Close();
                verbKey = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\shell\\" + verb);
                verbKey.SetValue("", desc);
                verbKey.Close();
                // Directory - shell
                cmdKey = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\" + verb + "\\command");
                cmdKey.SetValue("", cl);
                cmdKey.Close();
                verbKey = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\" + verb);
                verbKey.SetValue("", desc);
                verbKey.Close();
                // Drive
                cmdKey = Registry.ClassesRoot.CreateSubKey("Drive\\shell\\" + verb + "\\command");
                cmdKey.SetValue("", cl);
                cmdKey.Close();
                verbKey = Registry.ClassesRoot.CreateSubKey("Drive\\shell\\" + verb);
                verbKey.SetValue("", desc);
                verbKey.Close();
            } else if (arg.Equals("uninstall"))
            {
                Registry.ClassesRoot.DeleteSubKeyTree("Directory\\Background\\shell\\" + verb);
                Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shell\\" + verb);
                Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shell\\" + verb);
                Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shell\\" + verb);
            }
        }
    }
}