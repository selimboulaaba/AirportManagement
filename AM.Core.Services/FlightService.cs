using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }



        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            IList<Flight> flightsResult = new List<Flight>();
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure.Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.ToString().Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightId.ToString().Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival.ToString().Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration.ToString().Equals(filterValue))
                        {
                            flightsResult.Add(flight);
                        }
                    }
                    break;

                default:
                    break;
            }
            return flightsResult;
        }
        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                    dates.Add(flight.FlightDate);
            }
            return dates;
        }
        public IList<DateTime> GetFlightDates2(string destination)
        {
            return (from f in Flights
                    where f.Destination == destination
                    select f.FlightDate).ToList();

            return Flights.Where(f => f.Destination == destination)
                .Select(f => f.FlightDate).ToList();
        }

        public void ShowFlightDetails(Plane p)
        {
            var selectedFlights = Flights.Where(f => f.MyPlane.PlaneId == p.PlaneId);

            foreach (var flight in selectedFlights)
            {
                Console.WriteLine("flightDate" + flight.FlightDate.ToString()
                      + ";" + "Destination:" + flight.Destination);

            }
            //2eme proposition
            //foreach (var flight in p.Flights)
            //{
            //    Console.WriteLine("flightDate" + flight.FlightDate.ToString()
            //          + ";" + "Destination:" + flight.Destination);

            //}
        }

        public int GetWeeklyFlightNumber(DateTime date)
        {
            DateTime endDate = date.AddDays(7);
            
            return  Flights.Where(flight =>flight.FlightDate >= date && flight.FlightDate < endDate)
                           .Count();
        }

        public double GetDurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration).Average();
        }

        public IList<Flight> SortFlights()
        {
          return Flights.OrderByDescending(flight => flight.EstimatedDuration)
                .ToList();
        }

        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            return flight.Passengers
                .OrderBy(p => p.Birthdate)
                .Take(3).ToList();
        }

        public void ShowGroupedFlights()
        {
            var groupflights = Flights.GroupBy(f => f.Destination);
            foreach (var group in groupflights)
            {
                Console.WriteLine(group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
            
        }
    }
}
