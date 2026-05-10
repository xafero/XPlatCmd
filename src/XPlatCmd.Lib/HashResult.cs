namespace XPlatCmd.Lib
{
    public record HashResult(
        string Path,
        int Size,
        string Md5,
        string Sha256
    );
}