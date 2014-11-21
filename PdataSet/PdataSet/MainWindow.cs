using System;
using Gtk;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		// creamos neuva conexion sig linea
		MySqlConnection mySqlConnection = new MySqlConnection(
			"DaraSource=localhost;Database=dbprueba;User= ID=root;Password=sistemas");

		mySqlConnection.Open();
		string slectSql="select * from articulo";
		IDbDataAdapter dbDataAdapter = new MySqlDataAdapter(selectSql, mySqlConnection);
		DataSet dataSet = new DataSet();
		dbDataAdapter.Fill(dataSet);
		show (dataSet);
		DataTable dataTable = dataSet.Tables[0];
		DataRow dataRow = dataTable.Rows[0];
		dataRow["nombre"]=DateTime.Now.ToString();
		new MySqlCommandBuilder (MySqlDataAdapter);


		MySqlDataAdapter.RowUpdating+= delegate(object sender, MySqlRowUpdatingEventsArgs e){

			Console.WriteLine"e.Command.CommandText={0}",e.Command.Command.Text);
};
mySqlDataAdapter.Update (dataSet);
}

	private void show(DataSet dataSet){
			DataTable dataTable=dataSet.Tables [0];
			foreach (DataColumn dataColumn in dataTable.Columns)
			Console.WriteLine (dataColumn.ColumnName);
			foreach(DataRow dataRow in dataTable.Rows)
			Console.WriteLine(DataColumn dataColumn int dataTable.Columns)
			Console.WriteLine("{0}={1}" dataColumn.ColumnName,dataRow[dataColumn]);
			}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
