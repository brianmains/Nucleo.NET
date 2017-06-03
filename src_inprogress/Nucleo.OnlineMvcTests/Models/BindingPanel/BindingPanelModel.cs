using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Nucleo.Models.BindingPanel
{
	public class BindingPanelModel
	{
		public IEnumerable<BindingData> Data
		{
			get
			{
				return new BindingData[]
				{
					new BindingData { Name = "Sidney Crosby", City = "Pittsburgh", State = "PA" },
					new BindingData { Name = "Alex Ovechkin", City = "Washington", State = "DC" },
					new BindingData { Name = "Ryan Miller", City = "Buffalo", State = "NY" },
					new BindingData { Name = "Tim Thomas", City = "Boston", State = "MA" }
				};
			}
		}

		public IEnumerable<BindingData> EmptyData
		{
			get
			{
				return new BindingData[] { };
			}
		}

		public BindingData NullData
		{
			get { return null; }
		}
	}
}
