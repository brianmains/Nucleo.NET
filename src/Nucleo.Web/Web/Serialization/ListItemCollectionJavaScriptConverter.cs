using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Serialization;


namespace Nucleo.Web.Serialization
{
	//Taken from: http://www.asp.net/AJAX/Documentation/Live/ViewSample.aspx?sref=System.Web.Script.Serialization/cs/App_Code/ListItemCollectionConverter.cs
	public class ListItemCollectionJavaScriptConverter : JavaScriptConverter
	{

		public override IEnumerable<Type> SupportedTypes
		{
			//Define the ListItemCollection as a supported type.
			get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(ListItemCollection) })); }
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			ListItemCollection listType = obj as ListItemCollection;

			if (listType != null)
			{
				// Create the representation.
				Dictionary<string, object> result = new Dictionary<string, object>();
				ArrayList itemsList = new ArrayList();
				foreach (ListItem item in listType)
				{
					//Add each entry to the dictionary.
					Dictionary<string, object> listDict = new Dictionary<string, object>();
					listDict.Add("Text", item.Text);
					listDict.Add("Value", item.Value);
					listDict.Add("Enabled", item.Enabled);
					listDict.Add("Selected", item.Selected);
					itemsList.Add(listDict);
				}
				result["ItemsList"] = itemsList;

				return result;
			}
			return new Dictionary<string, object>();
		}

		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
				throw new ArgumentNullException("dictionary");

			if (type == typeof(ListItemCollection))
			{
				// Create the instance to deserialize into.
				ListItemCollection list = new ListItemCollection();

				// Deserialize the ListItemCollection's items.
				ArrayList itemsList = (ArrayList)dictionary["ItemsList"];
				for (int i = 0; i < itemsList.Count; i++)
					list.Add(serializer.ConvertToType<ListItem>(itemsList[i]));

				return list;
			}
			return null;
		}

	}
}