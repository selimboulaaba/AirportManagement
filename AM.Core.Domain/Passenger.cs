using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        //public int PassengerId { get; set; }
        [DataType(DataType.Date, ErrorMessage ="doit etre de type date")]
        [Display(Name ="Date of Birth")]
        public DateTime Birthdate { get; set; }
        [Key, MaxLength(7,ErrorMessage ="max length 7")]
        [MinLength(7, ErrorMessage ="min length 7")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[StringLength(7,MinimumLength =7 , ErrorMessage ="doit etre 7")]
        public long PassportNumber { get; set; }
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
        public string EmailAdress { get; set; }

        //[StringLength(25, MinimumLength = 3, ErrorMessage = "Le prénom doit avoir entre 3 et 25 caractères")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public FullName MyFullName { get; set; }
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        
        public string TelNumber { get; set; }
        public virtual IList<Flight> Flights { get; set; }
        private int age;
        public int Age { 
            get
            {
                
                age = DateTime.Now.Year - Birthdate.Year;
                if (Birthdate.AddYears(age) >= DateTime.Now)
                    age--;
                 return age;
            }
        }
        public virtual IList<Reservation>? Reservations { get; set; }
        public override string ToString()
        {
            return "Birthdate:" + Birthdate + ";"
                   + "PassportNumber:" + PassportNumber + ";"
                   + "EmailAdress:" + EmailAdress + ";"
                   //+ "FirstName:" + FirstName + ";"
                   //+ "LastName:" + LastName + ";"
                   + "TelNumber:" + TelNumber + ";";
        }
        //public bool CheckProfile(string FirstName, string LastName)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName;
        //}
        //public bool CheckProfile(string FirstName, string LastName, string Email)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName &&
        //          EmailAdress == Email;

        //}
        public bool CheckProfile(string FirstName, string LastName,string Email=null)
        {

            if (Email != null)

                return this.MyFullName.FirstName == FirstName && this.MyFullName.LastName == LastName && this.EmailAdress ==Email;

            else
                return this.MyFullName.FirstName == FirstName && this.MyFullName.LastName == LastName;
            

        }
        public virtual string GetPassengerType()
        {
            return "I am a passanger";
        }
        public  string GetPassengerType2()
        {
            if(this.GetType()  == typeof(Passenger))
            return "I am a passanger";
           else if (this.GetType() == typeof(Staff))
                return "I am a passanger, I am a staff member";
           else if (this.GetType() == typeof(Traveller))
                return "I am a Traveller";

            return null;
        }
    }
}
