using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_8
{
	public class Purple_2: Purple
	{
		private string[] _output;
		public string[] Output => _output;

		public Purple_2(string input): base(input){}

        private int[] GetSpaces(int amount_of_words, int symbols)
        {
            if (amount_of_words == 1 || amount_of_words == 0)
            {
                return new int[0];
            }
            int spaces = 50 - symbols;
            int[] arr = new int[amount_of_words - 1];
            int cnt = 0, i = 0;
            while (cnt < spaces)
            {
                arr[i++] += 1;
                cnt += 1;
                if (i == amount_of_words - 1)
                {
                    i = 0;
                }
            }
            return arr;
        }

        public override void Review()
		{
			if(Input  == null)
			{
				return;
			}
			int symbols = 0;
			string[] splitted = Input.Split(' ');
			string[] result = new string[0];
			string[] current = new string[0];
			

			for(int i = 0; i< splitted.Length; ++i)
			{
				if(symbols + current.Length + splitted[i].Length <= 50)
				{
					Array.Resize(ref current, current.Length + 1);
					current[^1] = splitted[i];
					symbols += splitted[i].Length;
				}
				else
				{
					int[] fillers = GetSpaces(current.Length, symbols);
					string wrd = current[0];
					for(int j = 0; j < fillers.Length; ++j)
					{
						wrd += new string(' ', fillers[j]) + current[j + 1];
					}
					Array.Resize(ref result, result.Length + 1);
					result[^1] = wrd;
					i--;
					current = new string[0];
					symbols = 0;
				}
			}
			if(current.Length > 0)
			{
				int[] fillers = GetSpaces(current.Length, symbols);
				string wrd = current[0];


				for(int j = 0; j < fillers.Length; j++)
				{
					wrd += new string(' ', fillers[j]) + current[j + 1];
				}

				Array.Resize(ref result, result.Length + 1);
				result[^1] = wrd;
			}

			_output = result;
			
		}

		public override string ToString()
		{
			if (_output == null || _output.Length == 0)
			{
				return "";
			}
 
			return String.Join(Environment.NewLine, _output);
		   }

	   }

	
}
