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


        public RoomOccupancy()
        {
            
        }  
    }

    public class Room
    {
        public Person Holder { get; set; }

        public List<Person> Guests { get; set; }

        public int Children
        {
            get => Guests.Where(p => p.Type == PersonType.Child).Count();
        }

        public int Adults
        {
            get => Guests.Where(p => p.Type == PersonType.Adult).Count() + 1;
        }

        public int Babies
        {
            get => Guests.Where(p => p.Type == PersonType.Baby).Count();
        }
    }
    

    public class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public PersonType Type { get; set; }

        public int Age { get; set; }
    }

    public enum PersonType { Adult, Child, Baby}


}
