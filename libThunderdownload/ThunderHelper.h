#pragma once
#include <iostream>
#include "DllLibrary.h"
#include "CharSet.h"
#include "XLStructs.h"
using namespace std;
class ThunderHelper
{

protected:
	CharSet cs;

	typedef bool(*XL_QueryTaskInfoEx)(HANDLE hTask, DownTaskInfo & stTaskInfo);
	typedef bool(*XL_GetFileSizeWithUrl)(const wchar_t * lpURL, INT64& iFileSize);
	typedef bool(*XL_StartTask)(HANDLE);
	typedef bool(*XL_StopTask)(HANDLE);
	typedef bool(*XLinit)(void);
	typedef bool (*XL_Uninit)(void) ;
	XL_QueryTaskInfoEx QueryTaskInfo;

	XLinit xlinit;
	XL_Uninit xlUninit ;
	XL_StartTask StartTask;
	XL_StopTask  StopTask;
	XL_GetFileSizeWithUrl  GetFileSizeWithUrl;
	typedef HANDLE(*CreateTaskByUrlFunc)(const wchar_t *pszUrl, const wchar_t *, const wchar_t *pszFileName, bool isResume);
	CreateTaskByUrlFunc  CreateTaskByUrl;
	DllLibrary dllHelper;
	HANDLE hTask = NULL;
public:
	DownTaskInfo downloadInfo;
	INT64 lnFileSize;

	void GatherDownloadInfo()
	{
		QueryTaskInfo(this->hTask, downloadInfo);
	}
	int ProvideSpeed()
	{
		return this->downloadInfo.nSpeed;
	}
	bool IsCreatingFile()
	{
		return this->downloadInfo.IsCreatingFile;
	}
	float DownloadingPercent()
	{
		return this->downloadInfo.fPercent;
	}
	int ResourceHot()
	{
		return this->downloadInfo.nSrcTotal;
	}
	/*INT64 GetFileSize(char * pszUrl)
	{
		GetFileSizeWithUrl(cs.Ansi2Unicode(pszUrl), lnFileSize);
		return  lnFileSize;
	}*/
	INT64 GetFileSize()
	{
		 lnFileSize = downloadInfo.nTotalSize ;
		return  lnFileSize;
	}
    // INT64 GetFileSizeEx
	bool InitXunLei()
	{
		bool bLinked =dllHelper.Link("xldl.dll");

		if (bLinked)
		{
			cout << "load xldl.dll sucess" << endl;

		 	bool bLocated = dllHelper.LocateFuction(&xlinit, "XL_Init");

			//xlinit = (XLinit)mylib.resolve("XL_Init");
			bool retflag = xlinit();
			if (retflag == false)
			{
				 cout << "initialize thunder failed" << endl;
				return false;
			}
			else
			{
				cout << "initialize thunder sucess" << endl;
				// HANDLE XL_CreateTaskByURL(const wchar_t *url, const wchar_t *path, const wchar_t *fileName, BOOL IsResume);
				  	bool bLocated = dllHelper.LocateFuction(&CreateTaskByUrl, "XL_CreateTaskByURL");
					if (!bLocated)
						cout<<"未能定位到函数 CreateTaskByUrl"<<endl;
					bLocated = dllHelper.LocateFuction(&StartTask, "XL_StartTask");
					if (!bLocated)
						cout << "未能定位到函数  XL_StartTask" << endl;
					bLocated = dllHelper.LocateFuction(&StopTask, "XL_StopTask");
					if (!bLocated)
						cout << "未能定位到函数 XL_StopTask" << endl;
					bLocated = dllHelper.LocateFuction(&QueryTaskInfo, "XL_QueryTaskInfoEx");
					if (!bLocated)
						cout << "未能定位到函数 XL_QueryTaskInfoEx" << endl;
					bLocated = dllHelper.LocateFuction(&GetFileSizeWithUrl, "XL_GetFileSizeWithUrl");
					if (!bLocated)
						cout << "未能定位到函数  XL_GetFileSizeWithUrl" << endl;
						bLocated = dllHelper.LocateFuction(&xlUninit,"XL_UnInit") ;
						if(!bLocated)
                          cout << "未能定位到函数  XL_UnInit" << endl;
				return true;
			}
		}
		else
		{
			 cout << "load xldl.dll failed" << endl;
			return false;
		}
	}

	bool BeginDownload(char * url,char * psFileStoreDirectory, char * filename)
	{
		const  wchar_t * wchs = cs.Ansi2Unicode (psFileStoreDirectory);
		 const  wchar_t * wurl = cs.Ansi2Unicode(url);
		const  wchar_t * wfileName = cs.Ansi2Unicode(filename);

		HANDLE retdown = CreateTaskByUrl(wurl, wchs, wfileName, true);
		if (retdown <= 0)
		{
			cout << "add thunder task failed" << endl;

			return false;

		}
		else
		{
			cout << "add thunder task sucess" << endl;
			this->hTask = retdown;
			return true;

		}

	}

	void Download()
	{
		this->StartTask(this->hTask);

	}
	void EndDownload()
	{
		this->StopTask(this->hTask);

	}
	void Dispose()
	{
      if( !xlinit() )
      {
          cout<<"Failed To Uninit ThunderPlatform"<<endl ;
      }

	}


};





