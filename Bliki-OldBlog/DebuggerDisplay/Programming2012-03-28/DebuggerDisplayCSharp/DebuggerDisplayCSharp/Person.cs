using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

namespace DebuggerDisplayCSharp
{
	//[DebuggerDisplay(@"Capacity=\{{Length,nq} / {Capacity,nq}\}")]
	[DebuggerDisplay("MemoryUsage=\\{{Length,nq} / {Capacity,nq}\\} ({(Length / (double)Capacity).ToString(\"p\"),nq})")]
	public class Test
	{
		public int Length { get; set; }
		public int Capacity { get; set; }

		public Test()
		{
			Length = 5;
			Capacity = 10;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}

	[DebuggerDisplay(@"{DebuggerDisplay}")]
	public class SuperHero : Person
	{
		public string Power { get; set; }

		public SuperHero(string name, int age, string power)
			: base(name, age)
		{
			Power = power;
		}

		private string DebuggerDisplay
		{
			get
			{
				return string.Format("{0} ({1})", base.DebuggerDisplay, Power);
			}
		}
	}


	//[Description("Test123"), DebuggerDisplay("This person is {Name}. {Age < 50 ? \"Young\" : \"Old\",nq}")]
	[DebuggerDisplay(@"{DebuggerDisplay}"), DebuggerTypeProxy(typeof(Person.PersonProxy))]
	public class Person
	{
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal class PersonProxy
		{
			//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private Person _p;

			//public Person Person { get { return _p; } }

			public PersonProxy(Person p)
			{
				_p = p;
			}

			
		}


		public virtual string Name { get; set; }
		public int Age { get; set; }
		public ContactDetails Contact { get; set; }

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			return string.Format("ToString: {0}", Name);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual string DebuggerDisplay
		{
			get { return "DebuggerDisplay: " + Name + " (" + Age.ToString() + ")"; }
		}


	}

	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public sealed class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		private string DebuggerDisplay
		{
			get { return string.Format("Student: {0} {1}", FirstName, LastName); }
		}
	}


	public class ContactDetails
	{
		public string Email { get; set; }
		public string Telephone { get; set; }
		public string Address { get; set; }

		public ContactDetails(string email, string tel, string address)
		{
			Email = email;
			Telephone = tel;
			Address = address;
		}
	}

	public static class Helpers
	{
		public static string DebuggerDisplay(object value)
		{
			FieldInfo field = typeof(ContactTypes).GetField(value.ToString());
         return field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                     .Cast<DescriptionAttribute>()
                     .Select(x => x.Description)
                     .FirstOrDefault();
		}
	}

	[DebuggerDisplay("{DebuggerDisplayCSharp.Helpers.DebuggerDisplay(this)}")]
	public enum ContactTypes
	{
		[Description("Uknown contacttype")]
		Unknown = 0,
		[Description("Home address")]
		Home = 1,
		[Description("Workplace address")]
		Work = 2,
		[Description("Parental address")]
		Billing = 4
	}
}
