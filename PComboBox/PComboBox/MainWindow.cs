using System;
using Gtk;
using System.Collections.Generic;
using System.Data;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		ulong idCategoria = 0;

		// creo lista de categorias con elementos 

		ComboBoxHelper comboBoxHelper = new ComboBoxHelper ();
		comboBoxHelper
			.ComboBox(comboBox)
			.Id((ulong)7)
			.SelectSql(" select id , nombre from categoria")
			.Init();


		new ComboBoxHelper (comboBox, (ulong)4, "select id , nombre from categoria");
		//comboBox.Fill ((ulong)7, "select id,nombre from categoria");

		propertiesAction.Activated += delegate {

			Console.WriteLine ("id={0}", id);
			Console.WriteLine ("id={0}", comboBox.GetDataById());
		};
}

	

 protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

public class Categoria{
	public Categoria(int id, string nombre){
		Id = id;
		Nombre = nombre;
	
	}
	public int Id{ get; set;}
	public string Nombre{ get; set; }

}