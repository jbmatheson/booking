using System;
using System.Collections.Generic;

public class HotelJim: IBookingManager {
    public struct Room {
        public string guest;
        public int number;
        public DateTime dateTime;

        public Room(string g, int n, DateTime dT)
        {
            this.guest = g;
            this.number = n;
            this.dateTime = dT;
        }
    }

    public readonly Room[] rooms;
    public int availableRoom;

    public HotelJim() {
        rooms = new Room[4];
        // Room 1
        rooms[0].guest = "";
        rooms[0].number = 101;
        rooms[0].dateTime = DateTime.Today;
        // Room 2
        rooms[1].guest = "";
        rooms[1].number = 102;
        rooms[1].dateTime = new DateTime(2020,5,28);
        // Room 3
        rooms[2].guest = "";
        rooms[2].number = 201;
        rooms[2].dateTime = DateTime.Today;
        // Room 4
        rooms[3].guest = "";
        rooms[3].number = 202;
        rooms[3].dateTime = DateTime.Today;
    }

    public bool IsRoomAvailable(int room, DateTime date) {
        for(int i = 0; i < rooms.Length; i++) {
            if(rooms[i].dateTime == date && rooms[i].number == room && rooms[i].guest == "") {
                availableRoom = i;
                return true;
            }
        }
        return false;
    }

    public void AddBooking(string guest, int room, DateTime date)
    {
        Room r = new Room(guest, room, date);

        if(IsRoomAvailable(room, date)) {
            rooms[availableRoom] = r;
            return;
        }

        Console.WriteLine("ERROR: That room is not available.");
    }

    public IEnumerable<int> getAvailableRooms(DateTime date) {
        IList<int> availableRooms = new List<int>();

        for (int i = 0; i < rooms.Length; i++) {
            if(rooms[i].dateTime == date && rooms[i].guest == "") {
                availableRooms.Add(rooms[i].number);
            }
        }

        return availableRooms as IEnumerable<int>;
    }
}
