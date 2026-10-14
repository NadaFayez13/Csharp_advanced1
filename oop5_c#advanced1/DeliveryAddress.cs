using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public class DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street} St., {City}";
        }

        public DeliveryAddress DeepCopy()
        {
            return new DeliveryAddress(City, Street, BuildingNumber);
        }
    }
}
