using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Nucleo.Collections;


namespace Nucleo.Web.ClientState
{
	public class ListClientStateData : ClientStateData
	{
		private ObjectCollection _additions = null;
		private ObjectCollection _removals = null;
		private ObjectCollection _updates = null;



		#region " Properties "

		/// <summary>
		/// Gets the additions that were made to the client state.
		/// </summary>
		public ObjectCollection Additions
		{
			get
			{
				if (_additions == null)
					_additions = new ObjectCollection();

				return _additions;
			}
		}

		/// <summary>
		/// Gets the removes that were made to the client state.
		/// </summary>
		public ObjectCollection Removals
		{
			get
			{
				if (_removals == null)
					_removals = new ObjectCollection();

				return _removals;
			}
		}

		/// <summary>
		/// Gets the removes that were made to the client state.
		/// </summary>
		public ObjectCollection Updates
		{
			get
			{
				if (_updates == null)
					_updates = new ObjectCollection();

				return _updates;
			}
		}

		#endregion



		#region " Constructors "

		public ListClientStateData()
			: base() { }

		public ListClientStateData(ClientStateDictionary values)
			: base(values) { }

		#endregion



		#region " Methods "

		new public static ListClientStateData FromJson(string json)
		{
			if (string.IsNullOrEmpty(json))
				throw new ArgumentNullException("json");

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new ListClientStateDataJavaScriptConverter() });

			return serializer.Deserialize<ListClientStateData>(json);
		}

		public override string ToJson()
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new ListClientStateDataJavaScriptConverter() });

			return serializer.Serialize(this);
		}

		#endregion
	}
}
