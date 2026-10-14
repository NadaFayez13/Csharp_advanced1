using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {

        private string destinationCountry;
        private decimal customsFee;
        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5m) + CustomsFee;
            }
        }


        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";
        }


        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }


        public override Shipment CopyShipment()
        {
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, Destination, DestinationCountry, CustomsFee);
        }


        public override Shipment DeepCopy()
        {
            return new InternationalShipment(
                TrackingCode,
                Description,
                Weight,
                DeliveryFee,
                Destination.DeepCopy(),
                DestinationCountry,
                CustomsFee
            );
        }



        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine($"Tracking Code      : {TrackingCode}");
            Console.WriteLine($"Description        : {Description}");
            Console.WriteLine($"Weight             : {Weight} KG");
            Console.WriteLine($"Delivery Fee       : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee        : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost     : {EstimatedCost} EGP");
        }
    }
}
