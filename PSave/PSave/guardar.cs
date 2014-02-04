using System;
using MySql.Data.MySqlClient;

namespace PSave
{
	public class guardar
		
		
	{
		public static object Load(Type type, string id) {
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
					propertyInfo.SetValue(obj, id, null); //TODO convert al tipo de destino
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null); //TODO convert al tipo de destino
			}
			dataReader.Close ();
			return obj;
			
			
		}
		public static void Save(Categoria categoria) {
			IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand ();
			updateDbCommand.CommandText = "update categoria set nombre=@nombre where id=" + categoria.Id;
			DbCommandUtil.AddParameter (updateDbCommand, "nombre", categoria.Nombre);
			updateDbCommand.ExecuteNonQuery ();			
		}
		
	}
}

