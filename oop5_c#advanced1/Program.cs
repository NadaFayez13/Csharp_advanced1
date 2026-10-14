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
            #endregion
        }
    }
}
