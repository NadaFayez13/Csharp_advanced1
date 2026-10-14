namespace oop5_c_advanced1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Theoretical Questions
            // q3 Static Members
            // a) What is a static field, and how is it different from an instance field ?
            // static field belongs to the class itself so all objects share the same copy of it.
            // an instance field belongs to each object so every object has its own copy.

            // b) What is a static method? Can a static method directly access instance members?
            //static method belongs to the class itself too and not to  specific object.this means we can call it directly using the class name without creating an object.
            //it cannot directly access instance members because they belong to individual objects and each object may have its own values..

            // c) What is a static constructor, and when is it executed? 
            // static constructor is a special parameterless method used to initialize static members,
            // it runs automatically only once before the first object is created or any static member is accessed.

            // d) What is a static class? Can you create an object from a static class?
            // static class is a class that can only contain static members and cannot be instantiated.
            // no cannot create an object from static class because it is not meant to be instantiated.


            // Q4  Extension Methods
            // a) What is an Extension Method?
            // extension method is static method in static class that lets you add new methods to existing types without modifying them or using inheritance.

            // b) What keyword must be used in the first parameter of an extension method?
            // this

            // c) Where must an extension method be declared?
            // it must be declared in static class.

            // d) Can an extension method access private members of the class it extends?
            // no


            //Q5  Partial Classes and Partial Methods
            // a) What is a partial class?
            // is a class that can be written in more than one file instead of keeping all its code in one file. 

            // b) Why would a developer split one class into multiple files?
            // to make the code more organized and easier to maintain especially for large classes.

            //c) What is a Partial Method?
            // is a method that can be defined in one part of a partial class and implemented in another part. it allows for optional implementation of methods.

            //d) What happens if a declared partial method has no implementation?
            // the compiler removes its declaration and any calls to it from the final code.
            #endregion


            #region Make sure all functionality from Assignment 04 still works
            DeliveryAddress address = new DeliveryAddress("Alexandria", "123 Main St", 21500);

            StandardShipment standard = new StandardShipment("SH001", "Books", 3.0m, 50.0m, address);

            ExpressShipment express = new ExpressShipment("SH002", "Mobile Phone", 1.5m, 60.0m, address, 20.0m);

            InternationalShipment international = new InternationalShipment("SH003", "Laptop", 2.5m, 100.0m, address, "Canada", 150.0m);

            DeliveryCenter center = new DeliveryCenter("Alexandria Hub");
            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Delivery Center");
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();

            center.PrintAllShipments();
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Tracking Status");
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();

            center.PrintTrackingStatuses();
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Insurance");
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();

            Console.Write("Standard Shipment Insurance : ");
            DeliveryReport.PrintInsurance(standard);
            DeliveryUtilities.PrintSeparator();

            Console.Write("Express Shipment Insurance  : ");
            DeliveryReport.PrintInsurance(express);
            DeliveryUtilities.PrintSeparator();

            Console.Write("International Shipment Insurance : ");
            DeliveryReport.PrintInsurance(international);
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("ITrackable Array - Tracking Statuses");
            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSeparator();

            ITrackable[] trackableShipments = new ITrackable[] { standard, express, international };

            foreach (ITrackable trackable in trackableShipments)
            {
                Console.WriteLine(trackable.GetTrackingStatus());
            }

            Console.WriteLine("IInsurable Array - Insurance Values");
            DeliveryUtilities.PrintSeparator();

            IInsurable[] insurableShipments = new IInsurable[] { standard, express, international };

            foreach (IInsurable insurable in insurableShipments)
            {
                Console.WriteLine($"Insurance Value: {insurable.CalculateInsurance()} EGP");
            }
            #endregion

            #region Demonstrate reference assignment between two shipment variables.
            StandardShipment shipment1 = new StandardShipment("0021", "Book", 2.0m, 40.0m, address);

            Shipment shipment2 = shipment1;
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Before Modification");
            Console.WriteLine($"Shipment 1 Weight: {shipment1.Weight} KG");
            Console.WriteLine($"Shipment 2 Weight: {shipment2.Weight} KG");

            shipment2.UpdateWeight(5.5m);
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("\n After Modifying Weight via Shipment 2");
            Console.WriteLine($"Shipment 1 Weight: {shipment1.Weight} KG");
            Console.WriteLine($"Shipment 2 Weight: {shipment2.Weight} KG");
            DeliveryUtilities.PrintSeparator();

            bool isSameObject = ReferenceEquals(shipment1, shipment2);
            Console.WriteLine($" {isSameObject}");
            #endregion

            #region Create a Shallow Copy using MemberwiseClone().
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("shallow copy demonstration");

            StandardShipment shallowOriginal = new StandardShipment("0133", "tablet", 1.2m, 35.0m, address);

            Shipment shallowCopied = shallowOriginal.ShallowCopy();

            bool isSameShipment = ReferenceEquals(shallowOriginal, shallowCopied);
            Console.WriteLine($"{isSameShipment}"); // false cause we just copied the reference of the original object

            Console.WriteLine($"Original Tracking Code : {shallowOriginal.TrackingCode}");
            Console.WriteLine($"Copied Tracking Code   : {shallowCopied.TrackingCode}");
            DeliveryUtilities.PrintSeparator();

            #endregion

            #region Demonstrate that the shallow copy shares the same DeliveryAddress.
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("\n shallow copy demonstration2");
            bool isSameAddress = ReferenceEquals(shallowOriginal.Destination, shallowCopied.Destination);
            Console.WriteLine($" {isSameAddress}");

            Console.WriteLine($"\nBefore Address Change Original City: {shallowOriginal.Destination.City}");

            shallowCopied.Destination.City = "el minia";

            Console.WriteLine($"After Changing City via Copied Shipment : {shallowOriginal.Destination.City}");
            DeliveryUtilities.PrintSeparator();

            #endregion

            #region Create a Deep Copy

            Console.WriteLine("deep copy demonstration");

            StandardShipment deepOriginal = new StandardShipment("55", "Laptop", 2.5m, 100.0m, new DeliveryAddress("Alexandria", "fouad St", 10));

            Shipment deepCopied = deepOriginal.DeepCopy();

            bool isSameShipmentDeep = ReferenceEquals(deepOriginal, deepCopied);
            Console.WriteLine($"{isSameShipmentDeep}");

            #endregion

            #region Demonstrate that the deep copy has an independent DeliveryAddress.

            Console.WriteLine("\nIndependent DeliveryAddress Demonstration");

            bool isSameAddressDeep = ReferenceEquals(deepOriginal.Destination, deepCopied.Destination);
            Console.WriteLine($"{isSameAddressDeep}");

            Console.WriteLine($"\nBefore Address Change to Original City: {deepOriginal.Destination.City}");

            deepCopied.Destination.City = "aswan";

            Console.WriteLine($"After Changing City via Deep Copied Shipment:");
            Console.WriteLine($"  Original City: {deepOriginal.Destination.City}");
            Console.WriteLine($"  Copied City  : {deepCopied.Destination.City}");
            #endregion

            #region  Add and demonstrate the static shipment counter and the static constructor.
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("\n Static Constructor Demonstration ");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine($"Total Shipments Created: {Shipment.TotalShipmentsCreated}");
            #endregion

            #region  Call GetTotalShipmentsCreated().
            Console.WriteLine("\n Call GetTotalShipmentsCreated()");
            int totalCreated = Shipment.GetTotalShipmentsCreated();
            Console.WriteLine($"Total Shipments Created : {totalCreated}");

            #endregion

            #region Create and use DeliveryUtilities

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Demonstrating DeliveryUtilities");

            DeliveryUtilities.PrintSeparator();
            #endregion

            #region Create and use ShipmentExtensions
            Console.WriteLine("\nCreate and use ShipmentExtensions Demonstration");
            DeliveryUtilities.PrintSeparator();
            StandardShipment extShipment = new StandardShipment("SH_EXT11", "lectronics", 2.9m, 41.0m, address);

            string summary = extShipment.GetSummary();
            Console.WriteLine($"Summary     : {summary}");

            bool deliveredStatus = extShipment.IsDelivered();
            Console.WriteLine($"Is Delivered: {deliveredStatus}");

            #endregion

        }

    } }

