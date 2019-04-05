
#include "ThunderHelper.h"
ThunderHelper *  hlper  = NULL;

extern "C" __declspec(dllexport) void GatherDownloadInfo()
{
	  (*hlper).GatherDownloadInfo();
}
extern "C" __declspec(dllexport) int ProvideSpeed()
{
	return (*hlper).ProvideSpeed();
}
extern "C" __declspec(dllexport) bool IsCreatingFile()
{
	return (*hlper).IsCreatingFile();
}
extern "C" __declspec(dllexport) float DownloadingPercent()
{
	return  (*hlper).DownloadingPercent();
}
extern "C" __declspec(dllexport) int ResourceHot()
{
	return (*hlper).ResourceHot();
}
extern "C" __declspec(dllexport) INT64 ProvideFileSize(
)
{
	return (*hlper).GetFileSize();
}

extern "C" __declspec(dllexport) bool InitXunLei()
{
    hlper  = new ThunderHelper() ;
	return (*hlper).InitXunLei();
}

extern "C" __declspec(dllexport)  bool BeginDownload(char * url, char * psFileStoreDirectory, char * filename)
{
	return (*hlper).BeginDownload(url, psFileStoreDirectory, filename);

}

extern "C" __declspec(dllexport) void Download()
{

	  (*hlper).Download();
}
extern "C" __declspec(dllexport) void EndDownload()
{
	(*hlper).EndDownload();
}
extern "C" __declspec(dllexport) void Dispose()
{
     delete hlper ;
    (*hlper).Dispose() ;
}


