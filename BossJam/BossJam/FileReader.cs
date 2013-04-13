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

        private FileReader()
        {
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

            string reader = sReader.ReadToEnd();

            //Save for later
            //mLadda = laser.ReadLine();

            ////Ladda slut position för banan
            //mLadda = laser.ReadLine();
            //LEVEL_END.X = float.Parse(mLadda);
            //mLadda = laser.ReadLine();
            //LEVEL_END.Y = float.Parse(mLadda);


            ////ladda in nya punkter och ersätt
            //for fixslutetavfil
            //{
            //    mLadda = laser.ReadLine();
            //    LEVELVECTOR.X = float.Parse(mLadda);
            //    mLadda = laser.ReadLine();
            //    LEVELVECTOR.Y = float.Parse(mLadda);
            //}

            //stäng fil
            sReader.Close();
            levelFile.Close();
        }

    }
}
