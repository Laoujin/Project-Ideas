using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DebuggerDisplayCSharp;

namespace TestBench
{
	public partial class Form1 : Form
	{
		public ContactTypes ContactType { get; set; }

		[Description("Test123")]
		public Person WhichPerson { get; set; }

		public Form1()
		{
			InitializeComponent();
			ContactType = ContactTypes.Billing;
			WhichPerson = new Person("SomeName", 15);
			var x = ContactType;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.propertyGrid1.SelectedObject = this;
		}
	}
}
