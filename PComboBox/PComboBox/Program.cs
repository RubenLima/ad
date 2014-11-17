using System;
using Gtk;
using MySql.Data.MySqlClient;
using Pserpisad;

namespace PComboBox
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
