using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Tags;


namespace Nucleo.Web.ListControls
{
	public class PageableListRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public PageableList Component
		{
			get { return (PageableList)base.Component; }
		}

		#endregion



		#region " Methods "

		protected virtual int GetItemCount()
		{
			return this.Component.Items.Count;
		}

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			//Write left pager image
			writer.Write(this.RenderPagerImage((this.Component.Orientation == Orientation.Horizontal)
				? this.Component.PagingOptions.LeftImageUrl
				: this.Component.PagingOptions.UpImageUrl).ToHtmlString());

			this.RenderItems(tag, writer);

			//Write right pager image
			writer.Write(this.RenderPagerImage((this.Component.Orientation == Orientation.Horizontal)
				? this.Component.PagingOptions.RightImageUrl
				: this.Component.PagingOptions.DownImageUrl).ToHtmlString());

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		protected TagElement RenderPagerImage(string url)
		{
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context != null)
			{
				Nucleo.Web.Context.Services.IUrlResolutionService urls = context.GetService<Nucleo.Web.Context.Services.IUrlResolutionService>();
				if (urls != null)
					url = urls.GetClientBasedUrl(url);
			}

			TagElement parent = TagElementBuilder.Create((this.Component.Orientation == Orientation.Horizontal) ? "SPAN" : "DIV");
			parent.Attributes.AppendAttribute("class", "PageableListPagerImage");

			parent.Children.AppendTag(TagElementBuilder.Create("IMG", new { src = url }));
			return parent;
		}

		protected virtual void RenderItems(TagElement parent, BaseControlWriter writer)
		{
			for (int index = 0, len = this.GetItemCount(); index < len; index++)
			{
				TagElement tag = TagElementBuilder.Create((this.Component.Orientation == Orientation.Horizontal) ? "SPAN" : "DIV");
				tag.Attributes.AppendAttribute("class", "PageableListItem");

				if (this.Component.VisibleItemCount > 0 &&
					!(this.Component.CurrentIndex <= index &&
					index < (this.Component.CurrentIndex + this.Component.VisibleItemCount)))
					tag.Styles.AppendAttribute("display", "none");
				writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

				this.RenderItemUI(index, writer);

				writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
			}
		}

		protected virtual void RenderItemUI(int index, BaseControlWriter writer)
		{
			((IRenderableControl)this.Component.Items[index]).RenderUI(writer);
		}

		#endregion
	}
}
