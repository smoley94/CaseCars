using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCars.Codes
{
    internal struct DateCalculation {
        // Her bliver bilens alder beregnet
        public int CarAge(string _dato) {
            DateTime _date = DateTime.ParseExact(_dato, "DD-MM-YYYY", System.Globalization.CultureInfo.InvariantCulture);

            int _age = (int)((DateTime.Now - _date).TotalDays / 365.242199);

            return _age;
        }

        // Her bliver string taget og konveteret til DateTime
        public DateTime StringToDateTime(string date) {
            DateTime _stringToDate = DateTime.ParseExact(date, "DD-MM-YYYY", System.Globalization.CultureInfo.InvariantCulture);

            return _stringToDate;
        }

        // Her bliver bilens sidste synsdato beregnet
        public double DoesCarNeedMot(string date) {
            DateTime _date = DateTime.ParseExact(date, "DD-MM-YYYY", System.Globalization.CultureInfo.InvariantCulture);

            double _status = (double)DateTime.Now.Subtract(_date).TotalDays / 365.242199;

            Math.Round(_status, 0);

            return _status;
        }
    }
}
