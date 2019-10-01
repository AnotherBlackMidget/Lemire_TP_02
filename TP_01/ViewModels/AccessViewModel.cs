using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_02.Models;

namespace TP_02.UI.ViewModels
{
    class AccessViewModel : BaseViewModel
    {
        public ObservableCollection<Access> Accesses { get; set; }
        Access _access;

        public AccessViewModel()
        {
            Accesses = new ObservableCollection<Access> ();

            _access = new Access() { WorkerId = 1, Name = "Dong Wang", CardId = 1, RoomId = 1, Desc = "Piscine", Hours="18h35 - 19h05" };
            Accesses.Add(_access);

            _access = new Access() { WorkerId = 1, Name = "Dong Wang", CardId = 1, RoomId = 2, Desc = "Cafeteria", Hours = "12h35 - 13h05" };
            Accesses.Add(_access);

            _access = new Access() { WorkerId = 1, Name = "Dong Wang", CardId = 1, RoomId = 3, Desc = "Placard du concierge", Hours = "06h35 - 18h05" };
            Accesses.Add(_access);



            _access = new Access() { WorkerId = 2, Name = "Yong Wayne", CardId = 2, RoomId = 2, Desc = "Cafeteria", Hours = "21h35 - 22h05" };
            Accesses.Add(_access);

            _access = new Access() { WorkerId = 2, Name = "Yong Wayne", CardId = 2, RoomId = 3, Desc = "Placard du concierge", Hours = "18h35 - 06h05" };
            Accesses.Add(_access);



            _access = new Access() { WorkerId = 3, Name = "Sum-Ting Wong", CardId = 3, RoomId = 2, Desc = "Cafeteria", Hours = "12h35 - 13h05" };
            Accesses.Add(_access);

            _access = new Access() { WorkerId = 3, Name = "Sum-Ting Wong", CardId = 3, RoomId = 4, Desc = "Hangar a bateaux", Hours = "04h35 - 16h05" };
            Accesses.Add(_access);



            _access = new Access() { WorkerId = 4, Name = "Wing Meng", CardId = 4, RoomId = 1, Desc = "Piscine", Hours = "14h35 - 16h05" };
            Accesses.Add(_access);
        }
    }
}
