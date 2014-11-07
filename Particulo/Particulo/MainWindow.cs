using Gtk;
using System;
using System.Data;
using PArticulo;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	private ListStore categoriaListStore;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();


		categoriaDeleteAction.Sensitive = false;

		categoriaEditAction.Sensitive = false;


		dbConnection = App.Instance.DbConnection;



		categoriaTreeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		categoriaTreeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		categoriaListStore = new ListStore (typeof(ulong), typeof(string));
		categoriaTreeView.Model = categoriaListStore;


		fillCategoriaListStore ();


		categoriaTreeView.Selection.Changed += categoriaSelectionChanged;



		categoriaRefreshAction.Activated += delegate{
			categoriaListStore.Clear();
			fillCategoriaListStore();
		};
		// todo resto de actions
	}




	private void categoriaSelectionChanged (object sender, EventArgs e) {
		Console.WriteLine ("selectionChanged");
		bool hasSelected = categoriaTreeView.Selection.CountSelectedRows () > 0;
		categoriaDeleteAction.Sensitive = hasSelected;
		categoriaEditAction.Sensitive = hasSelected;
	}
	private void fillArticuloListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select a.id,a.nombre,c.nombre as categoria,a.precio " + 
			" from articulo a left join categoria c on (a.categoria = c.id");

		IDataReader dataREader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
		object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
		object categoria = dataReader ["categoria"].ToString();
		object precio = dataReader ["precio"].ToString();	

		articuloListStore.AppendValues (id, nombre,categoria,precio);
		}
		dataReader.Close ();
	}

	private void fillCategoriaListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			categoriaListStore.AppendValues (id, nombre);
		}
		dataReader.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('{0}')",
			"Nuevo " + DateTime.Now
			);
		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();
		fillListStore ();
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar el registro?"
			);
		messageDialog.Title = Title;
		ResponseType response = (ResponseType) messageDialog.Run ();
		messageDialog.Destroy ();

		if (response != ResponseType.Yes)
			return;


		TreeIter treeIter;
		articuloTreeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		string deleteSql = string.Format ("delete from categoria where id={0}", id);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = deleteSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		articuloTreeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		CategoriaView categoriaView = new CategoriaView (id);
	}
	protected void OnArticuloRefreshActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}



}