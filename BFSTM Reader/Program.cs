using System;

namespace BFSTM_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetUpConsole();
#if DEBUG
            DisplayFileInfo("E:\\Splatoon\\Assets\\Sound Streams\\STRM_Plaza00_j.bfstm");
            return;
#endif
            if (args.Length == 0 || args == null)
            {
                AskForFileLocation();
                return;
            }
            DisplayFileInfo(args[0]);
        }

        static void SetUpConsole()
        {
            Console.Title = "BFSTM Reader";
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void AskForFileLocation()
        {
            Console.Write("What's the location of the BFSTM file? ");
            string fileLocation = Console.ReadLine();
            DisplayFileInfo(fileLocation);
        }

        static void DisplayFileInfo(string fileLocation)
        {
            Console.Clear();
            using (BFSTMFile bfstmFile = new BFSTMFile(fileLocation))
            {
                Console.WriteLine("Magic Bytes: " + new string(bfstmFile.MagicBytes()));
                Console.WriteLine("Byte Order Mark: " + ToHexString(bfstmFile.ByteOrderMark()));
                Console.WriteLine("Header Size: " + ToHexString(bfstmFile.HeaderSize()));
                Console.WriteLine("Version Number: " + bfstmFile.VersionNumber().ToString());
            }
            Console.ReadKey();
        }

        static string ToHexString(ushort value)
        {
            return "0x" + value.ToString("X");
        }
    }
}