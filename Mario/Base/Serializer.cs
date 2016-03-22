using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5_KPZ.Base
{
	public class Serializer
	{
		public static void Serialize(string fileName, Object data)
		{
			var formatter = new BinaryFormatter();
			var stream = new FileStream(fileName, FileMode.Create);
			formatter.Serialize(stream, data);
			stream.Close();
		}
		public static Object Deserialize(string fileName)
		{
			var stream = new FileStream(fileName, FileMode.Open);
			var formatter = new BinaryFormatter();
			return (Object)formatter.Deserialize(stream);
		}
	}
}
