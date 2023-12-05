using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Level6
    {
        public static void TheVariableShopReturns()
        {
            Console.WriteLine("Begin Original Variables");
            int Integer = 2;
            short ShortNumber = 5;
            long LongNumber = 200;
            byte ByteNumber = 25;
            sbyte SignedByte = -25;
            uint UIntNumber = 10;
            ushort UShortNumber = 11;
            ulong ULongNumber = 2000;
            char Character = 'a';
            string StringText = "Test String";
            float FloatNumber = 3.2f;
            double DoubleNumber = 3.2;
            decimal DecimalNumber = 3.2m;
            bool booltest = true;
            Console.WriteLine(Integer);
            Console.WriteLine(ShortNumber);
            Console.WriteLine(LongNumber);
            Console.WriteLine(ByteNumber);
            Console.WriteLine(SignedByte);
            Console.WriteLine(UIntNumber);
            Console.WriteLine(UShortNumber);
            Console.WriteLine(ULongNumber);
            Console.WriteLine(Character);
            Console.WriteLine(StringText);
            Console.WriteLine(FloatNumber);
            Console.WriteLine(DoubleNumber);
            Console.WriteLine(DecimalNumber);
            Console.WriteLine(booltest);
            Console.WriteLine("Begin New Variables");
            Integer = 4;
            ShortNumber = 3;
            LongNumber = 250;
            ByteNumber = 20;
            SignedByte = -55;
            UIntNumber = 20;
            UShortNumber = 12;
            ULongNumber = 20000;
            Character = 'c';
            StringText = "New Test String";
            FloatNumber = 3.4f;
            DoubleNumber = 3.8;
            DecimalNumber = 3.5m;
            booltest = false;
            Console.WriteLine(Integer);
            Console.WriteLine(ShortNumber);
            Console.WriteLine(LongNumber);
            Console.WriteLine(ByteNumber);
            Console.WriteLine(SignedByte);
            Console.WriteLine(UIntNumber);
            Console.WriteLine(UShortNumber);
            Console.WriteLine(ULongNumber);
            Console.WriteLine(Character);
            Console.WriteLine(StringText);
            Console.WriteLine(FloatNumber);
            Console.WriteLine(DoubleNumber);
            Console.WriteLine(DecimalNumber);
            Console.WriteLine(booltest);
        }
    }
}
