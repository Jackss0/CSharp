using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

//Using static
using static CSharp6.CSharp6;
using static CSharp6.CSharp6.OtherClass;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstName);
            Console.WriteLine(FullName);
            SomeMethod();
            int n = FullName.CountWords();
            int n2 = FullName.CountWords() + 2;
            Console.WriteLine("There's {0} {1} words", n, n2);

            //nameof expression
            Console.WriteLine(nameof(FirstName));
        }
    }

    static class CSharp6
    {
        //Read-only auto-properties
        public static string FirstName { get; } = "Josue";
        public static string LastName { get; set; } = "Tueros";

        static void GetProp()
        {
            //Cannot access to this prop, cause is read-only
            //FirstName = "xd";

        }

        //Auto-property initializers
        public static ICollection<string> Courses = new List<string>();

        //Props with body expression
        public static string FullName => $"{FirstName} {LastName}";

        public static int CountWords(this string text)
        {
            return text.Split(' ').Length;
        }

        public class OtherClass
        {
            public string MyProperty { get; set; }

            //NULL conditional operator
            public static void SomeMethod()
            {
                LastName = null;
                Console.WriteLine(LastName?.ToUpper());

                var list = new List<string>
                {
                    "1",
                    "2",
                    null
                };
                Console.WriteLine(list?[2]);
                Console.WriteLine(LastName?.ToUpper() ?? "default value");
                Console.WriteLine(list?[2] ?? "default list value");

                //String interpolation
                Console.WriteLine($"FullName: {FirstName} + {LastName}");

            }
        }

        public static Dictionary<int, string> messages = new Dictionary<int, string>
        {
            { 404, "Page not Found"},
            { 302, "Page moved, but left a forwarding address."},
            { 500, "The web server can't come out to play today."}
        };

        public static Dictionary<int, string> weCodes = new Dictionary<int, string>
        {
            [200] = "OK",
            [404] = "Page not Found",
            [302] = "Page moved, but left a forwarding address.",
            [500] = "The web server can't come out to play today."
        };
    }

}
