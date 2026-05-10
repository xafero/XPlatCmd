using System;
using System.IO;
using System.Security.Cryptography;

namespace XPlatCmd.Lib
{
    public static class Hashing
    {
        public static HashResult Compute(string filePath, int buffSize = 80 * 1024)
        {
            using var md5 = MD5.Create();
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);

            var size = 0;
            var buffer = new byte[buffSize];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                md5.TransformBlock(buffer, 0, bytesRead, null, 0);
                sha256.TransformBlock(buffer, 0, bytesRead, null, 0);
                size += bytesRead;
            }

            md5.TransformFinalBlock([], 0, 0);
            sha256.TransformFinalBlock([], 0, 0);

            var fileDir = Path.GetDirectoryName(filePath) ?? ".";
            var fileName = Path.GetFileName(filePath);

            return new HashResult(
                fileDir,
                fileName,
                size,
                Convert.ToHexString(md5.Hash!).ToLowerInvariant(),
                Convert.ToHexString(sha256.Hash!).ToLowerInvariant()
            );
        }
    }
}