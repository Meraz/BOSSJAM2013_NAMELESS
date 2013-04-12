using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace BossJam
{
    class FileReader
    {
        private string mOpenLevel;
        private string mLadda;


        public void readLevel()
        {


	    //Filnamn
	    mOpenLevel = "LEVELNAME.txt";


	        FileStream levelFile = new FileStream(mOpenLevel, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader laser = new StreamReader(levelFile);


            //Save for later
            //mLadda = laser.ReadLine();

            //Ladda slut position för banan
            mLadda = laser.ReadLine();
            LEVEL_END.X = float.Parse(mLadda);
            mLadda = laser.ReadLine();
            LEVEL_END.Y = float.Parse(mLadda);


            //ladda in nya punkter och ersätt
            for fixslutetavfil
            {
                mLadda = laser.ReadLine();
                LEVELVECTOR.X = float.Parse(mLadda);
                mLadda = laser.ReadLine();
                LEVELVECTOR.Y = float.Parse(mLadda);
            }
            

            //stäng fil
            laser.Close();
            levelFile.Close();


        }

    }
}
