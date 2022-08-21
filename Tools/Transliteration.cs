using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tools
{
	public static class Transliteration
	{
		private static readonly Dictionary<char, string> Dictionary;

		static Transliteration()
		{
			Dictionary = new Dictionary<char, string>
			{
				{'А', "a"},
				{'Б', "b"},
				{'В', "v"},
				{'Г', "g"},
				{'Д', "d"},
				{'Е', "e"},
				{'Ё', "e"},
				{'Ж', "zh"},
				{'З', "z"},
				{'И', "i"},
				{'Й', "j"},
				{'К', "k"},
				{'Л', "l"},
				{'М', "m"},
				{'Н', "n"},
				{'О', "o"},
				{'П', "p"},
				{'Р', "r"},
				{'С', "s"},
				{'Т', "t"},
				{'У', "u"},
				{'Ф', "f"},
				{'Х', "kh"},
				{'Ц', "c"},
				{'Ч', "ch"},
				{'Ш', "sh"},
				{'Щ', "shh"},
				{'Ъ', ""},
				{'Ы', "y"},
				{'Ь', ""},
				{'Э', "e"},
				{'Ю', "yu"},
				{'Я', "ya"},
				{'а', "a"},
				{'б', "b"},
				{'в', "v"},
				{'г', "g"},
				{'д', "d"},
				{'е', "e"},
				{'ё', "e"},
				{'ж', "zh"},
				{'з', "z"},
				{'и', "i"},
				{'й', "j"},
				{'к', "k"},
				{'л', "l"},
				{'м', "m"},
				{'н', "n"},
				{'о', "o"},
				{'п', "p"},
				{'р', "r"},
				{'с', "s"},
				{'т', "t"},
				{'у', "u"},
				{'ф', "f"},
				{'х', "kh"},
				{'ц', "c"},
				{'ч', "ch"},
				{'ш', "sh"},
				{'щ', "shh"},
				{'ъ', ""},
				{'ы', "y"},
				{'ь', ""},
				{'э', "e"},
				{'ю', "yu"},
				{'я', "ya"},
				{'a', "a"},
				{'b', "b"},
				{'c', "c"},
				{'d', "d"},
				{'e', "e"},
				{'f', "f"},
				{'g', "g"},
				{'h', "h"},
				{'i', "i"},
				{'j', "j"},
				{'k', "k"},
				{'l', "l"},
				{'m', "m"},
				{'n', "n"},
				{'o', "o"},
				{'p', "p"},
				{'q', "q"},
				{'r', "r"},
				{'s', "s"},
				{'t', "t"},
				{'u', "u"},
				{'v', "v"},
				{'w', "w"},
				{'x', "x"},
				{'y', "y"},
				{'z', "z"},
				{'A', "a"},
				{'B', "b"},
				{'C', "c"},
				{'D', "d"},
				{'E', "e"},
				{'F', "f"},
				{'G', "g"},
				{'H', "h"},
				{'I', "i"},
				{'J', "j"},
				{'K', "k"},
				{'L', "l"},
				{'M', "m"},
				{'N', "n"},
				{'O', "o"},
				{'P', "p"},
				{'Q', "q"},
				{'R', "r"},
				{'S', "s"},
				{'T', "t"},
				{'U', "u"},
				{'V', "v"},
				{'W', "w"},
				{'X', "x"},
				{'Y', "y"},
				{'Z', "z"},
				{'0', "0"},
				{'1', "1"},
				{'2', "2"},
				{'3', "3"},
				{'4', "4"},
				{'5', "5"},
				{'6', "6"},
				{'7', "7"},
				{'8', "8"},
				{'9', "9"},
				{' ', "-"},
				{'-', "-"}
			};
		}

		public static string Translit(string text, string missingCharactersReplacer = "")
		{
			if (text == null)
				return string.Empty;
			var builder = new StringBuilder();
			foreach (var ch in text)
				if (Dictionary.ContainsKey(ch))
					builder.Append(Dictionary[ch]);
				else
				{
					builder.Append(missingCharactersReplacer ?? "");
				}
			var result = builder.ToString().Trim('-');
			result = new Regex(@"[-]{2,}").Replace(result, "-");
			return result;
		}
	}
}