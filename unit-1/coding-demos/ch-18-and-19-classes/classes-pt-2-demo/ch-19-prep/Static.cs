using System;
namespace ch_19_prep
{
    // Convert to a family tree!!!
    public class Static
    {
        public static int staticId = 2;
        // Are able to have other data types as static
        public static string name = "Roger";

        public int nonStaticId = 1 + staticId;

        public Static()
        {
        }

        // Cant do this:
        //public int ChangeStaticId()
        //{
        //    this.staticId = 7;
        //}


        // Why am I using Static here?
        public static void GetStaticID()
        {
            // Why doesn't this work?
            //Console.WriteLine(this.staticId);

            // Where as this works?
            Console.WriteLine(staticId);
        }

        // But I am not using static here?
        public void GetNonStaticID()
        {
            Console.WriteLine(this.nonStaticId);
        }
    }
}
