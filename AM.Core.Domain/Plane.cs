using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    //public enum PlaneType
    //{
    //    Boing,
    //    Airbus
    //}
    public class Plane
    {

        [Range(0, int.MaxValue, ErrorMessage = "La capacité doit etre un entier positif")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType MyPlaneType { get; set; }
        public virtual IList<Flight> Flights{ get; set; }
        public override string ToString()
        {
            return "Capacity:" + Capacity + ";"
                   + "ManufactureDate:" + ManufactureDate + ";"
                   + "PlaneId:" + PlaneId + ";"
                   + "MyPlaneType:" + MyPlaneType + ";";
                  
        }
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            Capacity = capacity;
            ManufactureDate = date;
            MyPlaneType = pt;
        }

        public Plane()
        {
        }
    }
}
