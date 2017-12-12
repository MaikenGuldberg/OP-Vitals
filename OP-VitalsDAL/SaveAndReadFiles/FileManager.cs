using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_VitalsDAL
{
    public class FileManager
    {
        private string addressFileCalibration_ =
            @"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\Filingsystem\CalibrationFiles";

        private string addressFileMeasurements_ =
            @"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\Filingsystem\MeasurementFiles";

        private string addressFileComments_ = @"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\Filingsystem\Comments";

        private int CountSequences_ = 1;

        private string OperationFolder;

        public string GetOperationFolder()
        {
            return OperationFolder;
        }

        public void SetSequences(int numberofsequence)
        {
            CountSequences_ = numberofsequence;
        }
        //Laver en fil til calibreringenværdien. Denne er navngivet efter præcippet: Calibration + dato(day-month-year) + nummeret på denne dags kalibration +  csv
        //den første linje i filen beskriver hvad der er i de forskellige kolonner. I dette tilfælde: ConversionConstant(mmhg/mV) + TechnicianID
        //Calibrationsfilerne er også nummeret således at hvis der er lavet to kalibrationer på en dag bliver disse ikke overskrevet (nummeret denne fil får er = antal filer i folderen + 1)
        public void CreateCalibrationFile(double value, string technicianid, out string path) //overvej om der er flere ting vi gerne vil have gemt ned
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(addressFileCalibration_);
                int CountCalibrationfiles_ = dir.GetFiles().Length + 1;
                string fileName = "Calibration" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "_" + CountCalibrationfiles_ + ".csv";
                string path_ = System.IO.Path.Combine(addressFileCalibration_, fileName);

                FileStream input = new FileStream(path_, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fileWriter = new StreamWriter(input);
                fileWriter.WriteLine("ConversionConstant(mmhg/mV)" + ";" + "TechnicianID");
                fileWriter.WriteLine(value + ";" + technicianid);
                fileWriter.Close();
                path = path_;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.Write(e.ToString());
                path = "";
            }
        }

        //Laver en mappe til den pågældende operation. Denne er unik for lige denne operation og denne metode skal kun benyttes en gang lige når man starter målingen. Man skal gemme vejen for 
        //folderen ned i DTO til senere brug når man skal til at gemme sekvenserne i filer
        // folderen bliver navngivet efter metoden: Operation + dato (date-month-year) + tidspunkt (hour:min:sek)
        public string CreateAFolderToOperationFiles(DateTime dateoperation)
        {
            string foldername = "Operation" + dateoperation.Year + "-" + dateoperation.Month + "-" + dateoperation.Day + "_" + dateoperation.Hour + "-" + dateoperation.Minute + "-" + dateoperation.Second;
            string pathFolder = System.IO.Path.Combine(addressFileMeasurements_, foldername);
            System.IO.Directory.CreateDirectory(pathFolder);
            OperationFolder = pathFolder;
            return pathFolder;
        }

        //Indlæser en liste af dobbeltværdier til en csv-fil. Der ligger i en operationsmappe. Filen bliver navngivet efter princippet: sequence + sequencenumber (eks. 1) + csv
        //Til sidst tælles sekvensnummeret op således at den næste fil der bliver gemt ned ikke kommer til at hedde det samme og der er en vis orden i filerne.
        public void SaveMeasurementsInFile(List<double> list, string pathFolder, int sequencenumber)
        {
            try
            {
                string nameFile = "sequence" + sequencenumber + ".csv";
                string path_ = System.IO.Path.Combine(pathFolder, nameFile);
                FileStream input = new FileStream(path_, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fileWriter = new StreamWriter(input);
                fileWriter.WriteLine("Index" + ";" + "Value");
                for (int i = 0; i < list.Count; i++)
                {
                    fileWriter.WriteLine(i + ";" + list[i]); //der er også en metode der hedder asynkron... måske kan vi senere få brug for denne
                }
                fileWriter.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.Write(e.ToString());
            }
        }

        

        //Denne metode benyttes til at læse calibrationsfilen. Da der er beskrivelse over hver kolonne tjekkes der om der er tal i den første linje der indlæses hvis der ikker er det hentes der 
        // ikke noget ned. Hvis der er et tal hentes værdien ned og returneres.
        // Inden filen åbnes leder metoden efter den nyeste fil, ved at benytte metoden GetNewestFile() så man altid er sikker på at få den nyeste fil indlæst.
        public double ReadCalibrationFile()
        {
            double result = 0;
            string filepath = GetNewestFile(addressFileCalibration_);
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(filepath))
            {
                while (!streamReader.EndOfStream)
                {

                    var line = streamReader.ReadLine().Split(';');
                    if (line[0].Any(char.IsDigit) == false)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = Convert.ToDouble(line[0]);
                    }

                }
            }
            return result;
        }

        //Denne metode benyttes til at gemme kommentarer som en fil. Filen overskrives hele tiden når der trykkes på gem på ny.
        public string SaveComments(string[] comments)
        {
            try
            {

                string filename = "Comments.txt";
                string path_ = System.IO.Path.Combine(addressFileComments_, filename);
                using (System.IO.StreamWriter fs = new System.IO.StreamWriter(path_))
                {
                    foreach (var line in comments)
                    {
                        fs.WriteLine(line);
                    }
                }
                return path_;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.Write(e.ToString()); 
                throw;
            }
        }

        //Denne metode benyttes til at lede efter den nyeste fil i en folder og derefter returneres den fulde vej til filen
        private string GetNewestFile(string folderpath)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folderpath);
            var files = dir.GetFiles();
            string latestfile = "";
            DateTime lastupdate = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastupdate)
                {
                    lastupdate = file.LastWriteTime;
                    latestfile = file.FullName;
                }
            }
            return latestfile;
        }

    }
}
