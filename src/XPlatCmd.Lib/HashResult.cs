// ReSharper disable NotAccessedPositionalProperty.Global

namespace XPlatCmd.Lib
{
    public record HashResult(
        string Name,
        int Size,
        string Md5,
        string Sha256,
        string Folder
    )
    {
        public string Path() => $"{Folder}|{Name}";
    }
}