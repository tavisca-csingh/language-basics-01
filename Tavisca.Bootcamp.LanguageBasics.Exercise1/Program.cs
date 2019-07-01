using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
       static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2?*22=484", 2);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        //
        //method which return required digit which we send to the finddigit method which is in string form
        // 
        public static  string actualdigit(string z,string a)
        {
            for(int index=0;index<a.Length;index++)
                {
                    for(int zindex=0;zindex<z.Length;zindex++)
                    {
                        if(z[zindex]==a[index])
                        {
                            z=z.Remove(zindex,1);
                        }
                    }
                }
            return z;
        }

        public static int FindDigit(string equation)
        {
            
            string a="",b="",c="";
            //fetching all the operands from equation
            a=equation.Split("*")[0];
            b=equation.Split("*")[1].Split("=")[0];
            c=equation.Split("=")[1];
            //
            //checking for operand 1st
            //
            if(a.Contains('?'))
            {
                int d=Convert.ToInt32(b);
                int e=Convert.ToInt32(c);
                int y=e/d;

                if(e%d!=0)
                    return -1;

                string z=Convert.ToString(y);

                if(z.Length<a.Length)
                    return -1;
            
                string result=actualdigit(z,a);
                return Convert.ToInt32(result);
            }
            //
            //checking for operand 2nd
            //
            if(b.Contains('?'))
            {
                int d=Convert.ToInt32(a);
                int e=Convert.ToInt32(c);
                int y=e/d;

                if(e%d!=0)
                    return -1;

                string z=Convert.ToString(y);
                
                if(z.Length<b.Length)
                    return -1;

                string result=actualdigit(z,b);
                return Convert.ToInt32(result);
            }
            //
            //checking for resulant value
            //
            if(c.Contains('?'))
            {
                int d=Convert.ToInt32(b);
                int e=Convert.ToInt32(a);
                int y=e*d;
                string z=Convert.ToString(y);
                
                if(z.Length<c.Length)
                    return -1;

                string result=actualdigit(z,c);
                return Convert.ToInt32(result);
            }   
            
            throw new NotImplementedException();   
        }
    }
}
