using System;
using System.IO;

namespace BFSTM_Reader
{
    internal class BFSTMFile : IDisposable
    {
        private const long MAGIC_OFFSET = 0x00;

        private FileStream fileStream;
        private BinaryReader binaryReader;

        internal BFSTMFile(string fileLocation)
        {
            fileStream = new FileStream(fileLocation, FileMode.Open);
            binaryReader = new BinaryReader(fileStream);
        }

        internal char[] MagicBytes()
        {
            fileStream.Seek(MAGIC_OFFSET, SeekOrigin.Begin);
            return binaryReader.ReadChars(4);
        }

        public void Dispose()
        {
            binaryReader.Dispose();
            fileStream.Dispose();
        }
    }
}