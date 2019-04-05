using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XLPlatform
{
public class XLPlatformEx
{

    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GatherDownloadInfo();

    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int ProvideSpeed();
    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool IsCreatingFile();

    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    float DownloadingPercent();

    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    int ResourceHot();


    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    long ProvideFileSize();


    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    bool InitXunLei();


    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    bool BeginDownload(String url, String psFileStoreDirectory, String filename);


    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    void Download();

    [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern
    void EndDownload();
        [DllImport("libThunderDownload.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Dispose();

    }
}
