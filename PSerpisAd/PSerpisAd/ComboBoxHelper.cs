using System;
using System.Data;
using Gtk;
//using SerpisAd;

namespace SerpisAd
{
	public partial class ComboBoxHelper : Gtk.ActionGroup
	{
		public ComboBoxHelper (ComboBox comboBox ,object id ,string selectSql) {

			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText , false);
			comboBox.SetCellDataFunc(cellRendererText, new CellLayoutDataFunc(delegate (CellLayout cell_layout,Cell
		   cellRendererText.Text=((object[])tree_model.GetValue(Iter,0))[1].ToString();


			                                                                            }));
			                         //comboBox.AddAttribute (cellRendererText , "text", 1);

			ListStore listStore = new ListStore (typeof(object));
			object[] initial = new object [] { null, "<sin asignar>" };
			TreeIter initialTreeIter =  listStore.AppendValues ((ulong)0,"<sin asignar>");

			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select id, nombre from categoria";
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				object currentId = dataReader ["0"];
				object currentName = dataReader ["1"];
				object[]values = new object[] {currentId,currentName};
				TreeIter treeIter =	listStore.AppendValues ((object)values);
				if (currentId.Equals (current.Id))
					initialTreeIter = treeIter;
			}
			dataReader.Close ();

			comboBox.Model = listStore;
			comboBox.SetActiveIter (initialTreeIter);

		}
	}
}

