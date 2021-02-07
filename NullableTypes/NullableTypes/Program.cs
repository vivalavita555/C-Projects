using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime date = null;  won't work since a value type cannot be null. Instead:
            Nullable<DateTime> date = null;     //This variable can now have null OR a valid date-time
            DateTime? date2 = null;             //The shorthand for writing nullables is to append a ?

            //==============NULLABLE EXTENSION METHODS==============

            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());  // This is the superior way to check value since if there isn't a value instead of an exception, you just get the default type
            Console.WriteLine("HasValue: " + date.HasValue);                        // Just checks if it has value
            Console.WriteLine("Value: " + date.Value );                             // Displays the current value, however if there is not value ( in this case ) then an exception will be thrown

        }
    }
}
