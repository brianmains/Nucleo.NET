using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents the parent control to contain all of the sections within the form.
	/// </summary>
	/// <example>
	/// &lt;n:FormItemContainer ID="fc" runat="server">
	///		&lt;Sections>
	///			&lt;n:FormItemSection ID="s1" runat="server">..&lt;/n:FormItemSection>
	///			&lt;n:FormItemSection ID="s2" runat="server">..&lt;/n:FormItemSection>
	///		&lt;/Sections>
	///	&lt;/n:FormItemContainer>
	/// </example>
	public class FormItemContainer : BaseWebControl
	{
		#region " Properties "

		/// <summary>
		/// Gets the collection of sections.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public FormItemSectionCollection Sections
		{
			get { return (FormItemSectionCollection)this.Controls; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Changes the view for all sections.
		/// </summary>
		/// <param name="view">The view mode to change to.</param>
		public void ChangeViewForSections(FormCurrentView view)
		{
			foreach (FormItemSection item in this.Sections)
			{
				item.ChangeView(view);
			}
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new FormItemSectionCollection(this);
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			FormItemContainerRenderer renderer = new FormItemContainerRenderer();
			renderer.Initialize(this, this.Page);

			renderer.Render(writer);
		}

		#endregion
	}
}
