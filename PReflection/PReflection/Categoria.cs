using System;

namespace PReflection
{
	public class Categoria
	{

		public Categoria(ulong id , string nombre){
			this.id = id;
			this.Nombre = nombre;
		}
		[Id]
		public ulong Id { get; set;}
		public string Nombre{ get; set;}
		
	}
}

