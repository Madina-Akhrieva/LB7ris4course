using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LB7Me
{
    public class CrudFileLogicImpl
    {
        public static string Path = "D:\\file.txt";

        public  void AddData(string data)
        {
            var fileStream = FileStream();
            AddDataToFile(fileStream, data);
        }

        private static FileStream FileStream()
        {
            FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);
            fileStream.Seek(0, SeekOrigin.End);
            return fileStream;
        }

        private  void AddDataToFile(FileStream fileStream, string data)
        {
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(data);
            streamWriter.Close();
            fileStream.Close();
        }

    }
}
