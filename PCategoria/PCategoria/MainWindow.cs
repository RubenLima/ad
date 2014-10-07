
using Gtk;
using MySql.Data.MySqlClient;
using System;

public partial class MainWindow: Gtk.Window
{
	private ListStore listStore;
	private MySqlConnection mySqlConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		mySqlConnection = new MySqlConnection (
			"DataSource=localhost;Database=dbprueba;User ID=root:Password=sistemas");
		mySqlConnection.Open ();

		//anyadir columnas
		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		 listStore = new ListStore (typeof(string), typeof(string));

		treeView.Model = listStore; // en java seria treeView.setModel(listStore)



		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from categoria";

		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		while (mySqlDataReader.Read()) {
		object id = mySqlDataReader ["id"].ToString();
			// saber de que tipo es ,siguiente linea
			Console.WriteLine ("id.GetType()={0}", id.GetType ());
		object nombre = mySqlDataReader ["nombre"];
			listStore.AppendValues (id,nombre);
		
		}
		mySqlDataReader.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{

		string insertSql = string.Format(
		 "insert into categoria(nombre) values ('{0}')," +
			"nuevo" + DateTime.Now
				);
		Console.WriteLine ("Sql syntax error");//"insertSql ={0}",insertSql);
		//MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		//mySqlCommand.CommandText =insertSql;
			// textView.Buffer.Clear();
	}




	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear();
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from categoria";

		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		while (mySqlDataReader.Read()) {
			object id = mySqlDataReader ["id"].ToString();
			// saber de que tipo es ,siguiente linea
			Console.WriteLine ("id.GetType()={0}", id.GetType ());
			object nombre = mySqlDataReader ["nombre"];
			listStore.AppendValues (id,nombre);

		}
		mySqlDataReader.Close ();
	}

	private void selectionChanged (object sender,EventArgs e){

		Console.WriteLine ("selectionChanged");
	}
	private void fillListStore(){


		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from categoria";

		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		while (mySqlDataReader.Read()) {
			object id = mySqlDataReader ["id"].ToString ();
			// saber de que tipo es ,siguiente linea
			Console.WriteLine ("id.GetType()={0}", id.GetType ());
			object nombre = mySqlDataReader ["nombre"];
			listStore.AppendValues (id, nombre);



		}
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}

}
