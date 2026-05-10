namespace XPlatCmd.Lib
{
    public record HashResult(
        string Folder,
        string Name,
        int Size,
        string Md5,
        string Sha256
    )
    {
        public string Path() => $"{Folder}|{Name}";
    }
}