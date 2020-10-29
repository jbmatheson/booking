using System;
using System.Collections.Generic;

namespace booking
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelJim hotel = new HotelJim();
            DateTime today = DateTime.Today;
            Console.WriteLine(today); // Output today's date
            Console.WriteLine(hotel.IsRoomAvailable(101, today)); // return true

            hotel.AddBooking("Matheson", 101, today);

            Console.WriteLine(hotel.IsRoomAvailable(101, today)); // outputs false

            hotel.AddBooking("Moore", 101, today); // throws an error message

            IEnumerable<int> availRoomsToday = hotel.getAvailableRooms(today);
            foreach (int room in availRoomsToday) { // All rooms are instantiate with today's date except for one.
                Console.WriteLine("Room: " + room + " is currently available today!");
            }

            DateTime mayDate = new DateTime(2020,5,28);
            IEnumerable<int> availRoomsMay = hotel.getAvailableRooms(mayDate);
            foreach (int room in availRoomsMay) { // All rooms are instantiate with today's date except for one.
                Console.WriteLine("Room: " + room + " is available on " + mayDate);
            }
        }
    }
}
