using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_Group1_M16_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var OriginalArrayList = new ArrayList();
            var KeyArrayList = new ArrayList();
            var CodedArrayList = new ArrayList();
            var DecodedArrayList = new ArrayList();
            var coded = new StringBuilder();
            var decoded = new StringBuilder();
            string input;
            using (StreamReader r = new StreamReader(@"data.txt"))
            {
                int @char;
                while (((@char = r.Read()) != -1) && (@char != 13))
                    OriginalArrayList.Add((char)@char);

                r.Read(); // Reads \0x10 character since Enter == \0x13 \0x10

                while (((@char = r.Read()) != -1) && (@char != 13))
                    KeyArrayList.Add((char)@char);

                Console.Write("Word to encode  :");
                input = Console.ReadLine();

                foreach (char c in input)
                    CodedArrayList.Add((((OriginalArrayList.IndexOf(c)) != -1) ? (char)KeyArrayList[OriginalArrayList.IndexOf(c)] : c));
                foreach (char c in CodedArrayList)
                    coded.Append(c);

                foreach (char c in CodedArrayList)
                    DecodedArrayList.Add((((KeyArrayList.IndexOf(c)) != -1) ? (char)OriginalArrayList[KeyArrayList.IndexOf(c)] : c));
                foreach (char c in DecodedArrayList)
                    decoded.Append(c);
            }

            Console.Write("Encoded word    :");
            Console.WriteLine(coded);
            Console.Write("Decoded word    :");
            Console.WriteLine(decoded);
        }
    }
}
