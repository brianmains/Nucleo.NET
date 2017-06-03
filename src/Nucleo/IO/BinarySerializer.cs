using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Nucleo.IO
{
	public static class BinarySerializer
	{
		public static T DeserializeFromFile<T>(string filePath)
		{
			using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File));
				return (T)formatter.Deserialize(stream);
			}
		}

		public static T DeserializeFromBytes<T>(byte[] data)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Other));
				return (T)formatter.Deserialize(stream);
			}
		}

		public static void SerializeToFile(string filePath, object data)
		{
			using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File));
				formatter.Serialize(stream, data);
			}
		}

		public static byte[] SerializeToBytes(object data)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Other));
				formatter.Serialize(stream, data);

				return stream.ToArray();
			}
		}
	}
}
