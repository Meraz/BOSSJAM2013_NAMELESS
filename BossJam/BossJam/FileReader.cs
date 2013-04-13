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
        //private float [,]verts = new float[*];
        private string tempLoad;
        List<float> vertX;
        List<float> vertY;
        List<float> vertID;

        private FileReader()
        {
            vertX = new List<float>();
            vertY = new List<float>();
            vertID = new List<float>();
        }

        public static FileReader GetFileReader()
        {
            return mFileReader;

        }

        public void ReadFile(string fileName, string fileType)
        {
            
	        //Filnamn
            mFile = fileName + fileType;
            mFile = "random.txt";
            FileStream levelFile = new FileStream(mFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader sReader = new StreamReader(levelFile);



            int i = 0;
            do
            {
                if (!sReader.EndOfStream)
                {
                    tempLoad = sReader.ReadLine();
                    vertX.Add(float.Parse(tempLoad));
                }
                if (!sReader.EndOfStream)
                {
                    tempLoad = sReader.ReadLine();
                    vertY.Add(float.Parse(tempLoad));
                }
                if (!sReader.EndOfStream)
                {
                    tempLoad = sReader.ReadLine();
                    vertID.Add(float.Parse(tempLoad));
                }

            }
            while (!sReader.EndOfStream);


            //stäng fil
            sReader.Close();
            levelFile.Close();
        }

    }
}
