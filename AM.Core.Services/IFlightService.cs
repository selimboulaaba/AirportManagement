﻿using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService
    {
        IList<DateTime> GetFlightDates( string destination);
        IList<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane p);
        int GetWeeklyFlightNumber(DateTime date);
        double GetDurationAverage( string destination );
        IList<Flight> SortFlights();
        IList<Passenger> GetThreeOlderTravellers(Flight flight );
        void ShowGroupedFlights();
    }
}
