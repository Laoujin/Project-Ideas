using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebuggerDisplayCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Person> dict = new Dictionary<string, Person>();

			ContactTypes contactSimple = ContactTypes.Billing;
			ContactTypes multipleContacts = ContactTypes.Work | ContactTypes.Home;


			KeyValuePair<string, string> t = new KeyValuePair<string, string>("key", "value");
			Dictionary<string, string> dict2 = new Dictionary<string, string>()
				{
					{"key1", "val1"},
					{"key2", "val2"}
				};


			System.Text.StringBuilder builder = new StringBuilder();
			for (int i = 0; i < 1000; i++)
			{
				builder.AppendFormat("loop i is {0}", i.ToString());
				builder.AppendLine("tyaye");
				builder.AppendLine("tyaye");
			}

			Test tst = new Test();


			Person steven = new Person("Steven", 17);
			Person jemel = new Person("Jemel", 83);
			SuperHero batman = new SuperHero("Batman", 35, "None!?");

			

			var x = 0;
		}
	}
}
