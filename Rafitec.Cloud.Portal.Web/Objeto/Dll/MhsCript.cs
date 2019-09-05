using System.Runtime.InteropServices;

public class MhsCript
{
    [DllImport(@"DllCript.dll", CharSet = CharSet.Unicode)]
    public static extern void Criptografar(out string str, string param);
    [DllImport(@"DllCript.dll", CharSet = CharSet.Unicode)]
    public static extern void Decriptografar(out string str, string param);
}