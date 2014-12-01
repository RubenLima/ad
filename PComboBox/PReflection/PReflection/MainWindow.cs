using System;
using System.Reflection;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//showInfo(typeof(Categoria));
		//showInfo(typeof(Articulo));
		//showInfo(typeof(Button));

		Type type = typeof(MainWindow);
		Assembly assembly = type.Assembly;
		foreach(Type type in assembly.GetTypes())
			if(type.IsDefined(typeof(EntityAttribute),true))
		        Console.WriteLine("type.Name={0}", Type.Name);
		EntityAttribute etityAttribute=(EntityAttribute)
			Attribute.GetCustomAttribute(type,typeof(EntityAttribute));
		entityAttribute.TableName;
		//Console.WriteLine("type.Name={0} entityAttribute.TableName={1}"
		                 // , Type.Name,entityAttribute.TableName);
		Console.WriteLine("type.Name={0},Type.name);


		Categoria categoria = new Categoria (33, "");
//validate.categoria=
//categoria.Nombre="Algo";
		
		showValues (categoria);
		//Type type = typeof(Categoria);

		//PropertyInfo[] pro = type.GetProperties ();
				

		}

private void validate(object obj){
ErrorInfo[] erroInfos = Validator.Validate(categoria);
if(errosInfos.Length==0)
Combo.WriteLine("sin errores");
foreach(ErrorInfo errorInfo in errorInfos)
Console.WriteLine("property = {0} message ={1}",erroInfo.Property, errorInfo.Message);


}

	private void showValues(object obj){
	
		Type type = obj.GetType ();
		
		FieldInfo[] fields = type.GetFields ( BindingFlags.Instance| BindingFlags.NonPublic);
		foreach (FieldInfo field in fields ) 
			// saco por pantalla el nombre y las propiedades 
			object value= field.GetValue (obj); 
			Console.WriteLine ("nombre " + field.Name + "propiedades " + field.FieldType);
			
	}
	private void showInfo(Type type){

		foreach (PropertyInfo pro in type.GetProperties ()) 
			// saco por pantalla el nombre y las propiedades 
			Console.WriteLine ("nombre " + pro.Name + "propiedades " + pro.PropertyType);

		FieldInfo[] fields = type.GetFields ( BindingFlags.Instance| BindingFlags.NonPublic);
			foreach (FieldInfo field in fields ) 
				// saco por pantalla el nombre y las propiedades 
			//if(field.IsDefined(typeof(IdAttribute),true))
				Console.WriteLine ("nombre " + field.Name + "propiedades " + field.FieldType);

		
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
