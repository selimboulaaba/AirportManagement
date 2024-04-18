using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff :Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency,ErrorMessage ="currency")]
        public int Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+
                "EmploymentDate:" + EmploymentDate + ";"
                   + "Function:" + Function + ";"
                   + "Salary:" + Salary + ";"
                   ;

        }

        public override string GetPassengerType()
        {
            return "I am a passanger,I am a staff memeber";
        }
    }
    
    
}
