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
        public int DurationOperation_hour_ { get; set; }
        public int DurationOperation_min_ { get; set; }
        public int DurationOperation_sec_ { get; set; }
        public int Complikations_ { get; set; }
        public string PathCommentFile { get; set; }

        public string PathOperationFolder_ { get; set; }
        
        

        public OperationDTO()
        {
            NumberOfAlarms_ = 0;
            DurationOperation_hour_ = 0;
            DurationOperation_min_ = 0;
            DurationOperation_sec_ = 1;
            Complikations_ = 0;
            PathOperationFolder_ = "";
            PathCommentFile = "";
        }

    }
}
