using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Covid.DSS.Common.Utilities
{
    public static class FileTransformer
    {
        /// <summary>
        /// Transforms an <see cref="IFormFile"/> into an array of bytes and attempts to compress it
        /// </summary>
        /// <param name="file">The <see cref="IFormFile"/> to transform</param>
        /// <param name="compress">Enables compression</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this IFormFile file, bool compress = false)
        {
            if (file.Length == 0)
                return null;

            byte[] result;

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                result = stream.ToArray();
            }

            if (compress)
                result = Compress(result);

            return result;
        }

        /// <summary>
        /// Transforms an <see cref="IFormFile"/> into an array of bytes and attempts to compress it
        /// </summary>
        /// <param name="file">The <see cref="Stream"/> to transform</param>
        /// <param name="compress">Enables compression</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream file, bool compress = false)
        {
            if (file.Length == 0)
                return null;

            byte[] result;
            if (file.CanSeek)
            {
                file.Seek(0, SeekOrigin.Begin);
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                result = stream.ToArray();
            }

            if (compress)
                result = Compress(result);

            return result;
        }

        /// <summary>
        /// Attempts to compress a byte array using GZip
        /// </summary>
        /// <param name="source">The byte array to compress</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] source)
        {
            using (var memory = new MemoryStream())
            {
                using (var gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(source, 0, source.Length);
                }
                return memory.ToArray();
            }
        }

        /// <summary>
        /// Attempts to decompress a GZip byte array
        /// </summary>
        /// <param name="gzip">The GZip byte array</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // Then create a buffer and write into while reading from the GZIP stream.
            using (var stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 5120;
                byte[] buffer = new byte[size];
                using (var memory = new MemoryStream())
                {
                    int count;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }
}
