using System.Collections.Generic;
using System.Web.UI;
using Nucleo.Collections;

namespace Nucleo.Web
{
	public class ScriptDescriptorCollection : SimpleCollection<ScriptDescriptor>
	{
		#region " Constructors "

		public ScriptDescriptorCollection() { }

		public ScriptDescriptorCollection(ScriptDescriptor descriptor)
		{
			this.Items.Add(descriptor);
		}

		public ScriptDescriptorCollection(IEnumerable<ScriptDescriptor> descriptors)
		{
			this.Items.AddRange(descriptors);
		}

		#endregion



		#region " Methods "

		public void AddRange(IEnumerable<ScriptDescriptor> descriptors)
		{
			this.Items.AddRange(descriptors);
		}

		/// <summary>
		/// Gets a descriptor via its client type.
		/// </summary>
		/// <param name="clientTypeName">The name of the client type to find.</param>
		/// <returns>The script descriptor to find.</returns>
		public ScriptDescriptor GetByClientType(string clientTypeName, string clientID)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				ScriptDescriptorWrapper descriptor = new ScriptDescriptorWrapper((ScriptComponentDescriptor)this[index]);

				if (string.Compare(descriptor.Type, clientTypeName, true) == 0 &&
				 string.Compare(descriptor.ElementID, clientID, true) == 0)
					return descriptor.Descriptor;
			}

			return null;
		}

		public ScriptDescriptor GetByDetails(ScriptDescriptionRequestDetails details)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				ScriptDescriptorWrapper descriptor = new ScriptDescriptorWrapper((ScriptComponentDescriptor)this[index]);

				if (string.Compare(descriptor.Type, details.ClientType, true) == 0 &&
				 string.Compare(descriptor.ElementID, details.TargetID, true) == 0)
					return descriptor.Descriptor;
			}

			return null;
		}

		#endregion
	}
}
