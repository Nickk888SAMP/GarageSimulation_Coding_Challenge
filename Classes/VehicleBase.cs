using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSimulation_Codingchallenge.Classes
{
    public class VehicleBase
    {
        public string LicensePlate { get; set; } = null;

        public virtual void SetLicensePlate(string LicensePlate)
            => this.LicensePlate = LicensePlate.ToUpper();

        public virtual bool CompareLicensePlate(string LicensePlate)
            => this.LicensePlate.Equals(LicensePlate.ToUpper());
    }
}
