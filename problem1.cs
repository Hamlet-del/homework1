namespace console_app;

class Program
{
    static void Main(string[] args)
    {
        float dec = 123.456f;
        string bin32 = "01000010111101101110100101111001";
        string bin64 = "0100000001011110110111010010111100011010100111111011111001110111";

        void ieee32(float dec)
        {

            string bin = "";

            int left = (int)dec;
            double right = dec - left;

            while (left > 0)
            {
                int add = left % 2;
                bin = add.ToString() + bin;
                left = left / 2;
            }

            int exp = bin.Length + 126;


            for (int i = 0; i < 23 - bin.Length; i++)
            {
                right = right * 2;
                if (right >= 1)
                {
                    bin = bin + "1";
                    right -= 1;
                }
                else
                {
                    bin = bin + "0";
                }
            }

            bin = bin.Substring(1);

            while (exp > 0)
            {
                int add = exp % 2;
                bin = add.ToString() + bin;
                exp = exp / 2;
            }

            if (dec >= 0)
            {
                bin = "0" + bin;
            }
            else
            {
                bin = "1" + bin;
            }

            while (bin.Length < 32)
            {
                bin = bin + "0";
            }

            Console.WriteLine($"the 32 bit binar of {dec} is {bin}");
        }

        void ieee64(float dec)
        {

            string bin = "";

            int left = (int)dec;
            double right = dec - left;

            while (left > 0)
            {
                int add = left % 2;
                bin = add.ToString() + bin;
                left = left / 2;
            }

            int exp = bin.Length + 1022;


            for (int i = 0; i < 55 - bin.Length; i++)
            {
                right = right * 2;
                if (right >= 1)
                {
                    bin = bin + "1";
                    right -= 1;
                }
                else
                {
                    bin = bin + "0";
                }
            }

            bin = bin.Substring(1);

            while (exp > 0)
            {
                int add = exp % 2;
                bin = add.ToString() + bin;
                exp = exp / 2;
            }

            if (dec >= 0)
            {
                bin = "0" + bin;
            }
            else
            {
                bin = "1" + bin;
            }

            while (bin.Length < 64)
            {
                bin = bin + "0";
            }

            Console.WriteLine($"the 64 bit binar of {dec} is {bin}");
        }

        void Bin32ToFloat(string bin)
        {

            double result = 0;

            if (bin[0] == '0') 
            {
                int sign = 1;
            }
            else
            {
                int sign = -1;
            }

            string exp = bin.Substring(1, 8);
            string mant = bin.Substring(9, 23);

            double exp1 = 0;
            double mant1 = 0;

            for (int i = 0; i < exp.Length; i++)
            {
                exp1 = exp1 * 2 + (exp[i] - '0');
            }

            exp1 -= 127;


            for (int i = 0; i < mant.Length; i++)
            {
                mant1 += (mant[i] - '0') * Math.Pow(2, -1 - i);
            }

            mant1 += 1;

            result = mant1 * Math.Pow(2, exp1);

            Console.WriteLine($"the float of {bin} is {result}");
        }

        void Bin64ToFloat(string bin)
        {

            double result = 0;

            if (bin[0] == '0') 
            {
                int sign = 1;
            }
            else
            {
                int sign = -1;
            }

            string exp = bin.Substring(1, 11);
            string mant = bin.Substring(12, 52);

            double exp1 = 0;
            double mant1 = 0;

            for (int i = 0; i < exp.Length; i++)
            {
                exp1 = exp1 * 2 + (exp[i] - '0');
            }

            exp1 -= 1023;


            for (int i = 0; i < mant.Length; i++)
            {
                mant1 += (mant[i] - '0') * Math.Pow(2, -1 - i);
            }

            mant1 += 1;

            result = mant1 * Math.Pow(2, exp1);

            Console.WriteLine($"the float of {bin} is {result}");
        }

        ieee32(dec);
        ieee64(dec);
        Bin32ToFloat(bin32);
        Bin64ToFloat(bin64);
    }
}
