using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_02.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TP_02.UI.ViewModels
{
    class SecViewModel : BaseViewModel
    {
        public RelayCommand<IOpenable> OpenWindowCommand { get; private set; }
        public RelayCommand NextCommand { get; private set; }
        public RelayCommand PrevCommand { get; private set; }
        public RelayCommand AddRoomCommand { get; private set; }
        public RelayCommand RemoveRoomCommand { get; private set; }
        public RelayCommand AddAccCommand { get; private set; }
        public RelayCommand RemoveAccCommand { get; private set; }

        RoomViewModel _room;
        AccessViewModel _access;
        int iter;

        public Access SelectedItem { get; set; }

        public SecViewModel()
        {
            this.OpenWindowCommand = new RelayCommand<IOpenable>(this.OpenWindow);
            this.NextCommand = new RelayCommand(this.Next);
            this.PrevCommand = new RelayCommand(this.Prev);
            this.AddRoomCommand = new RelayCommand(this.AddRoom);
            this.RemoveRoomCommand = new RelayCommand(this.RemoveRoom);
            this.AddAccCommand = new RelayCommand(this.AddAcc);
            this.RemoveAccCommand = new RelayCommand(this.RemoveAcc);
            _room = new RoomViewModel();
            _access = new AccessViewModel();
            iter = 0;
        }


        private void OpenWindow(IOpenable window)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            CloseWindow(window);
        }

        private void Next()
        {
            if (iter < _room.Rooms.Count - 1)
            {
                iter++;
                OnPropertyChanged("Room");
                OnPropertyChanged("Access");
            }
        }

        private void Prev()
        {
            if (iter > 0)
            {
                iter--;
                OnPropertyChanged("Room");
                OnPropertyChanged("Access");
            }
        }

        private void AddRoom()
        {
            iter = _room.Rooms.Count;
            Room _newRoom = new Room() { RoomId = iter + 1, Desc = "Empty Room",};
            _room.Rooms.Add(_newRoom);
            OnPropertyChanged("Room");
            OnPropertyChanged("Access");

        }

        private void RemoveRoom()
        {
            if (_room.Rooms.Count > 0) _room.Rooms.RemoveAt(iter);
            if(iter>0) iter--;
            OnPropertyChanged("Room");
            OnPropertyChanged("Access");
        }
        private void AddAcc()
        {
            if (_room.Rooms.Count > 0)
            {
                Access _newAcc = new Access() { WorkerId = 0, Name = "New Employee", CardId = 0, RoomId = _room.Rooms[iter].RoomId, Desc = _room.Rooms[iter].Desc, Hours = "00h00 - 24h00" };
                _access.Accesses.Add(_newAcc);
            }  
            OnPropertyChanged("Access");
        }

        private void RemoveAcc()
        {
            _access.Accesses.Remove(SelectedItem);
            OnPropertyChanged("Employee");
            OnPropertyChanged("Access");
        }

        public Room Room
        {
            get { try { return _room.Rooms[iter]; } catch { return null; } }
        }

        public IEnumerable<Access> Access
        {
            get
            {
                if (_room.Rooms.Count > 0)
                {
                    return _access.Accesses.Where(a => a.RoomId == _room.Rooms[iter].RoomId);
                }
                else return null;
            }
        }
    }
}
