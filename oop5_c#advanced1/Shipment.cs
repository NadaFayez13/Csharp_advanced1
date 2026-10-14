using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public abstract partial class Shipment
    {
        public static int TotalShipmentsCreated { get; private set; } = 0;

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;


        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    trackingCode = value;
                }
            }
        }
        public Shipment(string trackingCode)
    : this(trackingCode, "Unknown", 1, 50, new DeliveryAddress("alex", "default Street", 1))
        {
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = "UNKNOWN";
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;
            this.Destination = destination;

            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;

            TotalShipmentsCreated++;
        }


        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight > 0 && extraPackingWeight >= 0)
            {
                Weight = newWeight + extraPackingWeight;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination { get; set; }

        public abstract decimal EstimatedCost { get; }
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public abstract Shipment CopyShipment();

        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public abstract Shipment DeepCopy();


        public abstract void PrintShipment();

        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }


    }
}
