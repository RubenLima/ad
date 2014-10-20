using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Button button = new Button ();
		button.Visible = true;
		Label label = new Label ("Etiqueta");
		Notebook.AppendPage (Button, label);

		add ("articulo");
		add ("categoria");

	//	TreeView.AppendColumn ("id", new CellRendererText (), "text", 0);
	//	TreeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
	//	TreeView.Model = new ListStore (typeof(long), typeof(string));
	}


	private void add(string label){
		Button button = new Button ();
		button.Visible = true;
		Label label = new Label (name;
		Notebook.AppendPage (Button, label);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
