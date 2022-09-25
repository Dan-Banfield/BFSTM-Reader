using System;
using System.IO;

namespace BFSTM_Reader
{
    internal class BFSTMFile : IDisposable
    {
        private const long MAGIC_OFFSET = 0x00;
        private const long BYTE_ORDER_MARK = 0x04;
        private const long HEADER_SIZE = 0x06;
        private const long VERSION_NUMBER = 0x08;

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

        internal ushort ByteOrderMark()
        {
            fileStream.Seek(BYTE_ORDER_MARK, SeekOrigin.Begin);
            return binaryReader.ReadUInt16();
        }

        internal ushort HeaderSize()
        {
            fileStream.Seek(HEADER_SIZE, SeekOrigin.Begin);
            return binaryReader.ReadUInt16();
        }

        internal int VersionNumber()
        {
            fileStream.Seek(VERSION_NUMBER, SeekOrigin.Begin);
            return binaryReader.ReadInt32();
        }

        public void Dispose()
        {
            binaryReader.Dispose();
            fileStream.Dispose();
        }
    }
}