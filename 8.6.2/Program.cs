using System;
using System.IO;
namespace _8._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write path to directory:");
            string Path = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo(Path);

            try
            {
                if (Directory.Exists(Path))
                {
                    Console.WriteLine();
                    Console.WriteLine( "Directory size: " + DirectoryExtension.DirSize(di) + " byte ");
                }
                else
                {
                    Console.WriteLine("Incorrect path to directory!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
            Console.ReadLine();
        }
        public static class DirectoryExtension
        { 
            public static long DirSize(DirectoryInfo d)
            {
                long size = 0;

                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }

                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
        }

    }
}
