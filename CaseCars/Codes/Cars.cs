using CaseCars.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CaseCars.Codes
{
    internal class Car {
        public Models CarData { get; set; }


        public Car(Models models) {
            CarData = models;
        }
    }
}

