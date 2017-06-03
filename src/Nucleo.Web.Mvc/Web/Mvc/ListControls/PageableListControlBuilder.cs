using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ListControls;
using Nucleo.Web.Settings;


namespace Nucleo.Web.Mvc.ListControls
{
	public class PageableListControlBuilder : BaseMvcControlBuilder<PageableList, PageableListControlBuilder>
	{
		private List<PageableListItemControlBuilder> _items = null;



		#region " Constructors "

		public PageableListControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public PageableListControlBuilder ImageOptions(PageableListPagingOptions imageOptions)
		{
			this.GetControl().PagingOptions = imageOptions;
			return this;
		}

		public PageableListControlBuilder ImageOptions(Action<PageableListPagingOptions> builder)
		{
			PageableListPagingOptions imageOptions = new PageableListPagingOptions();
			builder(imageOptions);

			return ImageOptions(imageOptions);
		}

		public PageableListControlBuilder Items(ListSettingsBuilder<PageableListItemControlBuilder> builder)
		{
			if (_items == null)
				_items = new List<PageableListItemControlBuilder>();

			_items.AddRange(builder.GetAll());
			return this;
		}

		public PageableListControlBuilder Items(Action<ListSettingsBuilder<PageableListItemControlBuilder>> builder)
		{
			ListSettingsBuilder<PageableListItemControlBuilder> list = new ListSettingsBuilder<PageableListItemControlBuilder>();
			builder(list);

			return this.Items(list);
		}

		public PageableListControlBuilder ListSettings(int startingIndex, int visibleItemCount)
		{
			if (startingIndex < 0)
				throw new ArgumentOutOfRangeException("startingIndex");
			if (visibleItemCount < 0)
				throw new ArgumentOutOfRangeException("visibleItemCount");

			this.GetControl().CurrentIndex = startingIndex;
			this.GetControl().VisibleItemCount = visibleItemCount;
			return this;
		}

		public PageableListControlBuilder Orientation(Orientation orientation)
		{
			this.GetControl().Orientation = orientation;
			return this;
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			PageableListMvcRenderer renderer = new PageableListMvcRenderer(_items);
			renderer.Initialize(this.GetControl(), this.ControlFactory.Page());
			renderer.Render(writer);
		}

		#endregion
	}
}
