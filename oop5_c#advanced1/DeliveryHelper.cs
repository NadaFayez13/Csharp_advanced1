using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment != null)
            {
                shipment.PrintShipment();
            }
        }
    }
}
