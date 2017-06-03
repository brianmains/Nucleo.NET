using System;
using System.Collections.Generic;

using Nucleo.ObjectModel;


namespace Nucleo.Web.Tags
{
	/// <summary>
	/// Represents the collection of attributes for an element.
	/// </summary>
	public class TagAttributeCollection
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the total number of attributes added to the list.
		/// </summary>
		public int AttributeCount
		{
			get { return this.Items.Count; }
		}

		private Dictionary<string, object> Items
		{
			get
			{
				if (_items == null)
					_items = new Dictionary<string, object>();
				return _items;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Appends an attribute to the underlying list.
		/// </summary>
		/// <param name="key">The key to append.</param>
		/// <param name="value">The value to append.</param>
		/// <returns>The collection of attributes, returned in chaining form.</returns>
		public TagAttributeCollection AppendAttribute(string key, object value)
		{
			this.Items.Add(key, value);
			return this;
		}

		/// <summary>
		/// Appends an attribute to the underlying list.
		/// </summary>
		/// <param name="attribute">The attribute details.</param>
		/// <returns>The collection of attributes, returned in chaining form.</returns>
		public TagAttributeCollection AppendAttribute(TagAttribute attribute)
		{
			this.Items.Add(attribute.Name, attribute.Value);
			return this;
		}

		/// <summary>
		/// Appends a range of attributes to the collection.
		/// </summary>
		/// <param name="attributes">The attributes to append in key/value form.</param>
		/// <returns>The collection of attributes with the newly appended ones.</returns>
		public TagAttributeCollection AppendAttributes(IDictionary<string, object> attributes)
		{
			if (attributes == null)
				throw new ArgumentNullException("attributes");

			foreach (KeyValuePair<string, object> pair in attributes)
			{
				if (this.Items.ContainsKey(pair.Key))
					this.ChangeAttributeValue(pair.Key, pair.Value);
				else
					this.Items.Add(pair.Key, pair.Value);
			}

			return this;
		}

		/// <summary>
		/// Appends a range of attributes to the collection.
		/// </summary>
		/// <param name="attributes">The attributes to append in object form.</param>
		/// <returns>The collection of attributes with the newly appended ones.</returns>
		public TagAttributeCollection AppendAttributes(IEnumerable<TagAttribute> attributes)
		{
			if (attributes == null)
				throw new ArgumentNullException("attributes");

			foreach (TagAttribute attribute in attributes)
				this.AppendAttribute(attribute.Name, attribute.Value);

			return this;
		}

		/// <summary>
		/// Changes the value of an attribute for a given key.
		/// </summary>
		/// <param name="key">The key of the attribute that will be changed (the key does not actually get changed, but is used for the lookup).</param>
		/// <param name="newValue">The value to update the attribute for, if the attribute exists.</param>
		/// <returns>The collection of attributes, returning in chaining form.</returns>
		public TagAttributeCollection ChangeAttributeValue(string key, object newValue)
		{
			this.Items[key] = newValue;
			return this;
		}

		/// <summary>
		/// Copies attributes from a dictionary into the attribute collection.  This will copy into this current collection.
		/// </summary>
		/// <param name="dictionary">The attribute collection to copy.</param>
		/// <returns>The collection of attributes that were copied, in chaining form.</returns>
		public TagAttributeCollection CopyFrom(TagAttributeCollection dictionary)
		{
			return this.CopyFrom(dictionary.ToDictionary());
		}

		/// <summary>
		/// Copies attributes from a dictionary into the attribute collection.  This will copy into this current collection.
		/// </summary>
		/// <typeparam name="T">The type of value in the collection being copied.</typeparam>
		/// <param name="dictionary">The dictionary to copy.</param>
		/// <returns>The collection of attributes that were copied, in chaining form.</returns>
		public TagAttributeCollection CopyFrom<T>(IDictionary<string, T> dictionary)
		{
			foreach (KeyValuePair<string, T> item in dictionary)
				this.Items.Add(item.Key, item.Value);

			return this;
		}

		public TagAttributeCollection CopyFrom(object objectWithAttributes)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(objectWithAttributes);

			return this.CopyFrom(reader.Attributes);
		}

		/// <summary>
		/// Gets the attribute object using the attributes name.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <returns>The attribute for the tag.</returns>
		public TagAttribute GetAttribute(string name)
		{
			if (this.Items.ContainsKey(name))
				return new TagAttribute(name, this.Items[name]);
			else
				return null;
		}

		/// <summary>
		/// Gets the collection of attributes within the tag.
		/// </summary>
		/// <returns>The collection of attributes.</returns>
		public IEnumerable<TagAttribute> GetAttributes()
		{
			List<TagAttribute> attributes = new List<TagAttribute>();

			foreach (KeyValuePair<string, object> item in this.Items)
				attributes.Add(new TagAttribute(item.Key, item.Value));

			return attributes;
		}

		/// <summary>
		/// Gets the value of an attribute using the attributes name.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <returns>The value of the attribute, or null if not found.</returns>
		public object GetAttributeValue(string name)
		{
			TagAttribute attribute = this.GetAttribute(name);
			return (attribute != null) ? attribute.Value : null;
		}

		/// <summary>
		/// Removes the attribute using the attribute's name.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <returns>The collection of attributes used in a chaining form.</returns>
		public TagAttributeCollection RemoveAttribute(string name)
		{
			this.Items.Remove(name);
			return this;
		}

		/// <summary>
		/// Converts the attribute collection to a dictionary.
		/// </summary>
		/// <returns>The dictionary list.</returns>
		public Dictionary<string, object> ToDictionary()
		{
			return this.Items;
		}

		/// <summary>
		/// Tries to append a collection of attributes to this collection.
		/// </summary>
		/// <param name="attributes">The attributes to append.</param>
		/// <returns>The base collection.</returns>
		public TagAttributeCollection TryAppendAttributes(IDictionary<string, object> attributes)
		{
			if (attributes == null)
				return this;

			try
			{
				this.AppendAttributes(attributes);
			}
			catch { }

			return this;
		}

		#endregion
	}
}
