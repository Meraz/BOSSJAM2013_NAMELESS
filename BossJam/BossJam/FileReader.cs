using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace BossJam
{
    sealed class FileReader
    {
        static private FileReader mFileReader = new FileReader();
        private string mFile;
        private List<string> mReadList;
        private List<float> mVertices;

        private FileReader()
        {
            mReadList = new List<string>();
            mVertices = new List<float>();
        }

        public static FileReader GetFileReader()
        {
            return mFileReader;
        }

        public void ReadFile(string fileName, string fileType)
        {
	        //Filnamn
            mFile = fileName + fileType;

            FileStream levelFile = new FileStream(mFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader sReader = new StreamReader(levelFile);

            sReader.Close();
            levelFile.Close();
        }

    }
}
