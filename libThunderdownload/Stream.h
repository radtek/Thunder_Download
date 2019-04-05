
#include<fstream>

#ifndef UNICODE_CHAR
#define TCHAR  char
#define  TFStream std::fstream  
#else
#define  TCHAR wchar_t  
#define TFStream  std::wfstream  
#endif // UNICODE_CHAR
 
class Stream
{
     TFStream * fs ; 
       
    public:

     void Open(const TCHAR * FileName,std::ios_base::openmode __openMode)
    {
         fs = new TFStream() ;
         fs->open(FileName ,__openMode) ;
    }
     
     void Read()
     {
             fs->read(,)
     }

     void Write()
     {

     }
    void Close()
    {
        fs->close() ;
        delete fs ;
    }
    
};
