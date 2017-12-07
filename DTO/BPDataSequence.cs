using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BPDataSequenceDTO
    {
        public int NumberOfSequences_ { get; set; }
        public double SequenceDuration_sec_ { get; set; }

        public BPDataSequenceDTO()
        {
            NumberOfSequences_ = 0;
            SequenceDuration_sec_ = 5000;
        }
    }
}
