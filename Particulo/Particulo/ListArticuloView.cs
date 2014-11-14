using System;
using System.Data;

namespace Particulo
{
	private IDbConnection dbConnection;
	private ListStore articuloListStore;


	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;

		editAction.Sensitive = false;



		dbConnection = App.Instance.DbConnection;

		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeView.AppendColumn ("categoria", new CellRendererText (), "text", 2);
		treeView.AppendColumn ("precio", new CellRendererText (), "text", 3);
		listStore = new ListStore (typeof(ulong), typeof(string),typeof(string),typeof(string));
		treeView.Model = listStore;



		fillListStore ();


		treeView.Selection.Changed += SelectionChanged;

		ArticuloRefreshAction.Activated += delegate{
			listStore.Clear();
			fillListStore();
		};

		ediatAction.Activated += delegate{

			new ArticuloView ();
		}

		// todo resto de actions
	}
	private void selectionChanged (object sender, EventArgs e) {
		Console.WriteLine ("selectionChanged");
		bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
	}
	private void fillListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select a.id,a.nombre,c.nombre as categoria,a.precio " + 
			" from articulo a left join categoria c on (a.categoria = c.id");

		IDataReader dataREader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			object categoria = dataReader ["categoria"].ToString();
			object precio = dataReader ["precio"].ToString();	

			listStore.AppendValues (id, nombre,categoria,precio);
		}
		dataReader.Close ();
	}
}

