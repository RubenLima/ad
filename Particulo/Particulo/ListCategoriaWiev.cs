using System;
using Gtk;
using System.Data;
using SerpisAd;


namespace Particulo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ListCategoriaWiev : Gtk.Bin
	{

		
		private IDbConnection dbConnection;
		private ListStore categoriaListStore;

		public ListCategoriaWiev ()
		{
			this.Build ();

			deleteAction.Sensitive = false;

			editAction.Sensitive = false;


			dbConnection = App.Instance.DbConnection;



			treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
			treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
			categoriaListStore = new ListStore (typeof(ulong), typeof(string));
			treeView.Model = categoriaListStore;


			fillCategoriaListStore ();


			treeView.Selection.Changed += selectionChanged;



			refreshAction.Activated += delegate{
				listStore.Clear();
				fillListStore();
			};
		}

		private void selectionChanged (object sender, EventArgs e) {
			Console.WriteLine ("selectionChanged");
			bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
			deleteAction.Sensitive = hasSelected;
			editAction.Sensitive = hasSelected;
		}

		private void fillListStore() {
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from categoria";

			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				object id = dataReader ["id"];
				object nombre = dataReader ["nombre"];
				listStore.AppendValues (id, nombre);
			}
			dataReader.Close ();
		}

	}
}

