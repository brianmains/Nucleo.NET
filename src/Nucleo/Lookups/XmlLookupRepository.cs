using System;
using System.Xml;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents a lookup repository that pulls from the XML file.
	/// </summary>
	public class XmlLookupRepository : ILookupRepository
	{
		private string _name = null;
		private string _path = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the repository.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the XML lookup repository.
		/// </summary>
		/// <param name="path">The path to the XML file.</param>
		public XmlLookupRepository(string path)
		{
			_path = path;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets all the applicable values from the XML file.
		/// </summary>
		/// <param name="criteria">The criteria for the XML file.</param>
		/// <returns>The collection of lookups.</returns>
		public LookupCollection GetAllValues(LookupCriteria criteria)
		{
			XmlDocument document = new XmlDocument();
			document.Load(_path);

			LookupCollection lookups = new LookupCollection();
			XmlNode group = document.DocumentElement.SelectSingleNode(string.Format("Group[name='{0}']", this.Name));
			if (group == null)
				return null;

			foreach (XmlElement lookupElement in group.ChildNodes)
			{
				if (criteria != null && !criteria.TimeframeDate.HasValue)
				{
					DateTime? effectiveDate = (lookupElement["EffectiveDate"] != null && lookupElement["EffectiveDate"].Value != null)
						? DateTime.Parse(lookupElement["EffectiveDate"].Value) : default(DateTime?);
					DateTime? endDate = (lookupElement["EndDate"] != null && lookupElement["EndDate"].Value != null)
						? DateTime.Parse(lookupElement["EndDate"].Value) : default(DateTime?);

					if (criteria.TimeframeDate.Value >= effectiveDate.GetValueOrDefault(DateTime.MinValue) &&
						criteria.TimeframeDate.Value <= endDate.GetValueOrDefault(DateTime.MaxValue)) { }
					else
						continue;
				}

				lookups.Add(new Lookup(
					lookupElement["Name"].Value,
					lookupElement["Value"].Value,
					(lookupElement["RepresentationCode"] != null)
						? lookupElement["RepresentationCode"].Value
						: null));
			}

			return lookups;
		}

		#endregion
	}
}
