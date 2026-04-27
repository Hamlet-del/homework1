namespace console_app;

class Program
{
    static void Main(string[] args)
    {
        float dec = 123.456f;

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

            Console.WriteLine("32bit    " + bin);
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

            Console.WriteLine("64bit    " + bin);
        }

        ieee32(dec);
        ieee64(dec);
    }
}
