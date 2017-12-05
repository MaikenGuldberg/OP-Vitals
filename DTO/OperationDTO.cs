using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OperationDTO
    {
        public int NumberOfAlarms_ { get; set; }
        public string Komments_ { get; set; }
        public int DurationOperation_hour_ { get; set; }
        public int DurationOperation_min_ { get; set; }
        public int DurationOperation_sec_ { get; set; }
        public int Complikations_ { get; set; }
        
        public string PathZipFolderOperation { get; set; }

        public DateTime StartTime_ { get; set; }

        public string PathOperationFolder_ { get; set; }
        
        // tilføjet af Margarit
        public int Systole { get; set; }
        public int Diastole { get; set; }

        public OperationDTO()
        {
            NumberOfAlarms_ = 0;
            Komments_ = "No Comments";
            DurationOperation_hour_ = 0;
            DurationOperation_min_ = 0;
            DurationOperation_sec_ = 1;
            Complikations_ = 0;
           
            StartTime_ = DateTime.Now;
            PathOperationFolder_ = "";
        }

    }
}
