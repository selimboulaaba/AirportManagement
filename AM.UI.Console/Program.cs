// See https://aka.ms/new-console-template for more information


using AM.Core.Domain;
using AM.Data;
using Microsoft.EntityFrameworkCore;

//Console.WriteLine("Hello, World!");
//Plane plane = new Plane();
//plane.Capacity = 1;
//plane.ManufactureDate = DateTime.Now;
//plane.MyPlaneType= PlaneType.Boing;

//Plane plane2 = new Plane(PlaneType.Boing,2,DateTime.Now);

//Plane plane3 = new Plane()
//{
//    Capacity = 1,
//    ManufactureDate = DateTime.Now,
//    MyPlaneType = PlaneType.Boing

//};

//Passenger passenger = new Passenger();
//Passenger staff = new Staff();
//Passenger traveller = new Traveller();
//Console.WriteLine( passenger.GetPassengerType());
//Console.WriteLine(staff.GetPassengerType());

//Console.WriteLine(traveller.GetPassengerType());

AMContext dbContext = new AMContext();

Plane plane3 = new Plane()
{
    Capacity = 1,
    ManufactureDate = DateTime.Now,
    MyPlaneType = PlaneType.Boing

};
dbContext.Add(plane3);
dbContext.SaveChanges();

Flight flight = new Flight()
{
   Destination = "St Petersburg", 
   Comment = "russia nice" , 
   Departure = "Cartage",
   FlightDate = DateTime.Now,
    EstimatedDuration = 2,
    EffectiveArrival = DateTime.Now,
    MyPlane = plane3,
};
dbContext.Add(flight);
dbContext.SaveChanges();

var passenger = new Passenger
{
    PassportNumber = 1238567,
    Birthdate = new DateTime(2000, 5, 15),
    EmailAdress = "selim@esprit.tn",
    TelNumber = "123456789",
};
passenger.MyFullName = new FullName
{
    FirstName = "Selim",
    LastName = "Boulaaba"
};
dbContext.Add(passenger);
dbContext.SaveChanges();

var reservation = new Reservation
{
    Flight = flight,
    Passenger = passenger,
    SeatNumber = "AAA3",
    Price = 566.00m,
    VIP = true
};
dbContext.Add(reservation);
dbContext.SaveChanges();
