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
        }
    }
}
