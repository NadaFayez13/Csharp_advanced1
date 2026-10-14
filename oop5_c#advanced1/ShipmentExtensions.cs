using System;
using System.Collections.Generic;
using System.Text;

namespace oop5_c_advanced1
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null) return string.Empty;

            string shipmentType = shipment.GetType().Name.Replace("Shipment", "");
            if (string.IsNullOrEmpty(shipmentType))
            {
                shipmentType = "Standard";
            }

            string trackingStatus = "Unknown";
            if (shipment is ITrackable trackable)
            {
                string fullStatus = trackable.GetTrackingStatus();
                if (fullStatus.Contains("Delivered"))
                    trackingStatus = "Delivered";
                else if (fullStatus.Contains("Out for Delivery"))
                    trackingStatus = "Out for Delivery";
                else if (fullStatus.Contains("Ready"))
                    trackingStatus = "Ready";
                else
                    trackingStatus = fullStatus;
            }

            return $"{shipment.TrackingCode} | {shipmentType} | {shipment.Weight} KG | {trackingStatus}";
        }
        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment is ITrackable trackable)
            {
                return trackable.GetTrackingStatus().Equals("Shipment " + shipment.TrackingCode + " has been Delivered.", StringComparison.OrdinalIgnoreCase)
                    || trackable.GetTrackingStatus().ToLower().Contains("delivered");
            }
            return false;
        }
    }
}
