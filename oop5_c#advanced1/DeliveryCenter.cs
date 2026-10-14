using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public class DeliveryCenter
    {

        public Driver Driver { get; set; }
        private Shipment[] shipments = new Shipment[20];
        private int count = 0;
        public DeliveryCenter()
        {
            shipments = new Shipment[10];
            count = 0;
        }

        private string centerName;

        public string CenterName
        {
            get { return centerName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    centerName = value;
                }
            }
        }
        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }
        public Shipment this[int index]
        {
            get
            {
                if (shipments != null && index >= 0 && index < count)
                {
                    return shipments[index];
                }
                return default;
            }
            set
            {
                if (shipments != null && index >= 0 && index < count)
                {
                    shipments[index] = value;
                }
            }
        }
        public Shipment this[string code]
        {
            get
            {
                if (shipments != null && !string.IsNullOrWhiteSpace(code))
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (shipments[i].TrackingCode != null &&
                            shipments[i].TrackingCode.Equals(code, StringComparison.OrdinalIgnoreCase))
                        {
                            return shipments[i];
                        }
                    }
                }
                return default;
            }
        }
        public bool AddShipment(Shipment shipment)
        {
            if (shipments == null)
            {
                shipments = new Shipment[20];
            }

            if (count < 20)
            {
                shipments[count] = shipment;
                count++;
                return true;
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }
                    shipments[count - 1] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("Delivery Center");

            if (Driver != null)
            {
                Console.WriteLine($"Driver : {Driver.Name}\n");
            }

            foreach (var shipment in shipments)
            {
                if (shipment != null)
                {
                    shipment.PrintShipment();
                }
            }
        }
        public int Count
        {
            get { return count; }
        }


        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is ITrackable trackableShipment)
                {
                    DeliveryReport.PrintShipment(trackableShipment);
                }
            }
        }
    }
}
