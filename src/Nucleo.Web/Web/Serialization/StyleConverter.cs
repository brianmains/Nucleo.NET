using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections.Generic;


namespace Nucleo.Web.Serialization
{
	public class StyleConverter : JavaScriptConverter
	{
		private Page _page = null;



		#region " Constructors "

		public StyleConverter(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			_page = page;
		}

		#endregion



		#region " Methods "

		public override object Deserialize(System.Collections.Generic.IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
				throw new ArgumentNullException("dictionary");
			if (!(type.Equals(typeof(Style))))
				throw new ArgumentException("The type provided is not a style");

			throw new NotImplementedException();
		}

		public override System.Collections.Generic.IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");
			if (!(obj is Style))
				throw new ArgumentException("The object being serialized is not a control");

			Dictionary<string, object> values = new Dictionary<string, object>();
			values.Add("Style", ((Style)obj).GetStyleAttributes(_page).Value);

			return values;
		}

		public override System.Collections.Generic.IEnumerable<Type> SupportedTypes
		{
			get { return new Type[] { typeof(Style) }; }
		}

		#endregion
	}
}
