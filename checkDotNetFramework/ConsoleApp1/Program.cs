using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace getDotNetVersion
{
    class Program
    {
        private const string V_4_dot_8= "4.8 ++";
        private const string V_4_dot_7_dot_2 = "4.7.2";
        private const string V_4_dot_7_dot_1 = "4.7.1";
        private const string V_4_dot_7 = "4.7";
        private const string V_4_dot_6_dot_2 = "4.6.2";
        private const string V_4_dot_6_dot_1 = "4.6.1";
        private const string V_4_dot_6 = "4.6";
        private const string V_4_dot_5_dot_2 = "4.5.2";
        private const string V_4_dot_5_dot_1 = "4.5.1";
        private const string V_4_dot_5 = "4.5";

        static void Main(string[] args)
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    string value = $"Detected .NET Framework Version: {CheckFor45PlusVersion((int)ndpKey.GetValue("Release"))}";
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");

                }

                Console.Write("\n");
                Console.Write("\nPress 'E' to exit the process...");

                // here it ask to press "E" to exit 
                while (Console.ReadKey().Key != ConsoleKey.E)
                {
                }
            }

            // Checking the version using >= enables forward compatibility.
            static string CheckFor45PlusVersion(int releaseKey)
            {
                if (releaseKey >= 528040)
                    return V_4_dot_8; 
                if (releaseKey >= 461808)
                    return V_4_dot_7_dot_2;
                if (releaseKey >= 461308)
                    return V_4_dot_7_dot_1;
                if (releaseKey >= 460798)
                    return V_4_dot_7;
                if (releaseKey >= 394802)
                    return V_4_dot_6_dot_2;
                if (releaseKey >= 394254)
                    return V_4_dot_6_dot_1;
                if (releaseKey >= 393295)
                    return V_4_dot_6;
                if (releaseKey >= 379893)
                    return V_4_dot_5_dot_2;
                if (releaseKey >= 378675)
                    return V_4_dot_5_dot_1;
                if (releaseKey >= 378389)
                    return V_4_dot_5;
                // This code should never execute. A non-null release key should mean
                // that 4.5 or later is installed.
                return "No 4.5 or later version detected";
            }
        }


    }


}
