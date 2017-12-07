using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    public class FilterFactory
    {
        private DAQSettingsDTO _daqDTO;
        private FilterSettingsDTO _filterSettings;

        public FilterFactory(DAQSettingsDTO daqDTO,FilterSettingsDTO filterSettings)
        {
            _daqDTO = daqDTO;
            _filterSettings = filterSettings;
        }

        public IFilter CreateFilter()
        {
            if (string.Equals(_filterSettings.filtersetting, "Butterworth"))
            {
                return new ButterworthFilter(_daqDTO);
            }
            else if (string.Equals(_filterSettings.filtersetting, "NoFilter"))
            {
                return new NoFilter();
            }
            else
            {
                throw new Exception(_filterSettings.filtersetting + " er ikke en valid filtertype");
            }
        }
    }
}
