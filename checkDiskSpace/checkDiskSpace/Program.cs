using System;
using System.IO;

namespace checkDiskSpace
{
    class Program
    {
        private const double BytesInMB = 1048576;
        private const double BytesInGB = 1073741824;

        static void Main(string[] args)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
         
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("\n\tDrive {0}", d.Name);
                Console.WriteLine("\tDrive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("\tVolume label: {0}", d.VolumeLabel);
                    Console.WriteLine("\tFile system: {0}", d.DriveFormat);
                    Console.WriteLine("\tAvailable space to current user: " + Math.Round(d.AvailableFreeSpace / BytesInMB,1) +" MB \t or : " + Math.Round(d.AvailableFreeSpace / BytesInGB,1)+" GB");
                    Console.WriteLine("\tTotal available space:\t "+ Math.Round(d.TotalFreeSpace / BytesInMB, 1) + "MB\t or " + Math.Round(d.TotalFreeSpace / BytesInGB, 1) + " GB");
                    Console.WriteLine("\tTotal size of drive:\t "+ Math.Round(d.TotalSize / BytesInMB, 1) + " MB\t or " + Math.Round(d.TotalSize / BytesInGB, 1) + " GB");
                    double freeSpacePercentage = (d.TotalFreeSpace /(float) d.TotalSize) * 100;
                    Console.WriteLine("\tPercentage of Free Space:\t\t\t {0,1} %",Math.Round(freeSpacePercentage,2));

                }
            }
            Console.WriteLine("\t\nPress a key to close this window..");
            Console.ReadLine();
        }
    }
}
