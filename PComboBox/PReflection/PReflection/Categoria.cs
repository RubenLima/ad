using System;

namespace PReflection
{
	[Entity(TableName="category")]
	public class Categoria
	{

		public Categoria(ulong id , string nombre){
			this.Id = id;
			this.Nombre = nombre;
		}
		[Id]
		public ulong Id { get; set;}
		public string Nombre{ get; set;}
		
	}
}

