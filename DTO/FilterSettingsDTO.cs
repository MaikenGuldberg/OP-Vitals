using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FilterSettingsDTO
    {
        public string filtersetting { get; set; }

        public FilterSettingsDTO()
        {
            filtersetting = "Butterworth";
        }
    }
}
