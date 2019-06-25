using System;

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
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int i,j;
            string a="",b="",c="";
            //fetching all the operands from equation
            for(i=0;i<equation.IndexOf('*');i++)
            {
                a=a+equation[i];
            }

            for(i=equation.IndexOf('*')+1;i<equation.IndexOf('=');i++)
            {
                b=b+equation[i];
            }

            for(i=equation.IndexOf('=')+1;i<equation.Length;i++)
            {
                c=c+equation[i];
            }
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
                for(j=0;j<a.Length;j++)
                {
                    if(z.Contains(a[j]))
                    {
                
                    z=z.Replace(a[j],' ');
                    }
                }

                    return Convert.ToInt32(z);
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
                for(j=0;j<b.Length;j++)
                {
                    if(z.Contains(b[j]))
                     z=z.Replace(b[j],' ');
                    
                }

                 return Convert.ToInt32(z);
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
                for(j=0;j<c.Length;j++)
                {
                    if(z.Contains(c[j]))
                     z=z.Replace(c[j],' ');
                    
                }
                
                    return Convert.ToInt32(z);
            }
        
            
            throw new NotImplementedException();   
        }
    }
}
