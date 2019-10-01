using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_02.Models;
using System.Collections.ObjectModel;

namespace TP_02.UI.ViewModels
{
    class RoomViewModel : BaseViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }
        Room _room;

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();

            _room = new Room() { RoomId = 1, Desc = "Piscine"};
            Rooms.Add(_room);

            _room = new Room() { RoomId = 2, Desc = "Cafeteria" };
            Rooms.Add(_room);

            _room = new Room() { RoomId = 3, Desc = "Placard du concierge" };
            Rooms.Add(_room);

            _room = new Room() { RoomId = 4, Desc = "Hangar a bateaux" };
            Rooms.Add(_room);
        }
    }
}
