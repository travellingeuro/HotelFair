using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Text;

namespace HotelFair.Models
{
    public class RoomOccupancy : BindableBase
    {        
        public List<Room> Rooms { get; set; }

        public override string ToString()
        {
            var r = Rooms.Count().ToString();
            return $"roomQuantity={r}";
        }

    }
    public class Room
    {
        public Paxes Holder { get; set; }

        public List<Paxes> Guests { get; set; }

        public int Children
        {
            get => Guests.Where(p => p.Type == PersonType.CH).Count();
        }

        public string ChildAges
        {
            get => getlistofages();
        }

        private string getlistofages()
        {
            string ages = null;
            foreach (var pax in Guests)
            {
                
                if (pax.Type==PersonType.CH)
                {
                    ages = ages + $",{pax.Age}";
                    ages.Remove(0, 1);
                }
            }
            return $"childAges={ages}";
        }

        public string Adults
        {
            get => GetNumberofAdults();
                
        }

        private string GetNumberofAdults()
        {
            var number= Guests.Where(p => p.Type == PersonType.AD).Count() + 1;
            return $"adults={number}";
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
