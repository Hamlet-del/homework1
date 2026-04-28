using System.Reflection.Metadata;

namespace console_app;

class Program
{
    static void Main(string[] args)
    {
        int a = int.MaxValue;
        Console.WriteLine(unchecked(a + 1));
        long b = long.MaxValue;
        Console.WriteLine(unchecked(b + 1));

        Console.WriteLine(Add("9999", "1"));
        Console.WriteLine(Substract("9999", "1"));
        Console.WriteLine(Multiply("123", "456"));
    }

    static string Normalise(string s)
    {
        if (string.IsNullOrEmpty(s)) 
        {
            return "0";
        }

        foreach(char c in s)
        {
            if(c < '0' || c > '9')
            {
                return "0";
            }
        }

        int i = 0;
        while (i < s.Length && s[i] == '0') 
        {
            i++;
        }
        s = s.Substring(i);
        return s;
    }

    static string Add(string a, string b) 
    {
        a = Normalise(a);
        b = Normalise(b);

        string result = "";
        int carry = 0;

        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int digitA = 0;
            if (i >= 0)
            {
                digitA = a[i] - '0';
            }

            int digitB = 0;
            if (j >= 0)
            {
                digitB = b[j] - '0';
            }

            int summ = digitA + digitB + carry;
            result = summ % 10 + result;
            carry = summ / 10;

            i--;
            j--;
        }
        return result;
    }

    static string Substract(string a, string b) 
    {
        a = Normalise(a);
        b = Normalise(b);

        string result = "";
        int borrow = 0;

        int i = a.Length - 1;
        int j = b.Length - 1;

        while(i >= 0)
        {
            int digitA = a[i] - '0';
            int digitB = 0;
            digitA = digitA - borrow;

            if(j >= 0)
            {
                digitB = b[j] - '0';
            }

                if(digitA < digitB)
                {
                    digitA = digitA + 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                int sub = digitA - digitB;
                result = sub.ToString() + result;

                i--;
                j--;
        }
            return (Normalise(result));
    }

    static string Multiply(string a, string b)
    {
        a = Normalise(a);
        b = Normalise(b);

        int[] result = new int[a.Length + b.Length];

        for (int i = a.Length - 1; i >= 0; i--)
        {
            for (int j = b.Length - 1; j >= 0; j--)
            {
                int digitA = a[i] - '0';
                int digitB = b[j] - '0';

                int multip = digitA * digitB;
                int sum = multip + result[i + j + 1];


                result[i + j + 1] = sum % 10;
                result[i + j] = result [i + j] + sum / 10;
            }
        }
        
        string res = "";
        
        for (int k = 0; k < result.Length; k++)
        {
            if(!(res == "" && result[k] == 0))
            {
                res = res + result[k];
            }
        }

        if(res == "")
        {
            return "0";
        }
        else
        {
            return res;
        }
    }
}
