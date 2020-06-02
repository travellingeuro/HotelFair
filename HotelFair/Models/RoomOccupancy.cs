using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Text;

namespace HotelFair.Models
{
    public class RoomOccupancy : BindableBase
    {        
        public ObservableCollection<Room> Rooms { get; set; }

        public RoomOccupancy()
        {
            this.Rooms = new ObservableCollection<Room>();
            for (int i = 1; i < 5; i++)
            {
                var room = new Room() { Id=i};
                Rooms.Add(room);
            }
        }

        public override string ToString()
        {
            var r = Rooms.Count().ToString();
            return $"roomQuantity={r}";
        }

    }
    public class Room
    {
        public int Id { get; set; }

        public Paxes Holder { get; set; }

        public ObservableCollection<Paxes> Guests { get; set; }

        public int Children { get; set; }

        public string ChildAges => Getlistofages();

        private string Getlistofages()
        {

            var ages = String.Empty;
            if (Children==0)
            {
                return null;
            }
            else
            {
                var childrenlist = Guests.Where(p => p.Type == PersonType.CH).ToList();
                for (int i = 0; i < Children; i++)
                {
                    ages = ages + $",{childrenlist[i].Age}";
                }
            }

            ages=ages.Remove(0,1);
            return $"childAges={ages}";
        }

        public int Adults { get; set; }

        public string GetAdultsNumber()
        {

            return $"adults={Adults}";
            
        }

        public Room()
        {
            this.Holder = new Paxes() {Type=PersonType.AD};
            this.Guests = new ObservableCollection<Paxes>();
            for (int i = 1; i < 9; i++)
            {
                var guest = new Paxes() { Type = PersonType.AD };
                Guests.Add(guest);
            }
            for (int i = 1; i < 4; i++)
            {
                var child = new Paxes() { Type = PersonType.CH, Age = 0 };
                Guests.Add(child);
            }
            this.Adults = 1;
        }

    }    

    public class Paxes
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public PersonType Type { get; set; }

        public int Age { get; set; }

    }

    public enum PersonType { AD, CH }

}
