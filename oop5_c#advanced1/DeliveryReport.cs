using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    internal class DeliveryReport
    {

        public static void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }


        public static void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"Insurance Cost: {shipment.CalculateInsurance()} EGP");
        }
    }
}
