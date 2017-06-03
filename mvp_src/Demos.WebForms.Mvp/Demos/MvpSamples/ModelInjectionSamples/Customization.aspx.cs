using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.ModelInjectionSamples
{
	public class TestCustomizationData
	{
		public string City;
		public string State;
	}

	public class CustomModelInspector : IModelInspector
	{
		public IModelInjection FindInjectionDefinition(ModelInspectorOptions options)
		{
			if (options.Property.Name.EndsWith("Injection"))
				return new CustomInjection();
			else
				return null;
		}
	}

	//Serves as a marker to say we have a specific type of injection.
	public class CustomInjection : IModelInjection { }

	public class CustomInjectionLoader : IModelDataLoader
	{
		public object GetModelData(ModelMemberMetadata metadata)
		{
			//Can use metadata.ValueType to inspect the output type for injection purposes
			//Can also use metadata.Attributes to inspect the custom attributes

			return new TestCustomizationData[]
			{
				new TestCustomizationData { City = "Pittsburgh", State = "PA" },
				new TestCustomizationData { City = "Philadelphia", State = "PA" },
				new TestCustomizationData { City = "Washington", State = "DC" },
				new TestCustomizationData { City = "Baltimore", State = "MD" },
				new TestCustomizationData { City = "Arlington", State = "VA" }
			};
		}

		public bool SupportsInjection(IModelInjection injection)
		{
			return (injection is CustomInjection);
		}
	}

	public class CustomizationModel
	{
		public TestCustomizationData[] First { get; set; }

		public TestCustomizationData[] SecondInjection { get; set; }

		public TestCustomizationData[] Third { get; set; }

		public TestCustomizationData[] FourthInjection { get; set; }
	}

	public interface ICustomizationView : IView<CustomizationModel>
	{

	}

	public class CustomizationPresenter : BasePresenter<ICustomizationView>
	{
		public CustomizationPresenter(ICustomizationView view)
			: base(view)
		{
			View.Starting += View_Starting;
		}

		protected override PresenterContext CreatePresenterContext()
		{
			var ctx = base.CreatePresenterContext();

			//Replace the defaults
			ctx.ModelInjection.Inspector = new CustomModelInspector();
			ctx.ModelInjection.RegisterBinding(new CustomInjectionLoader());

			return ctx;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new CustomizationModel();
			this.CurrentContext.ModelInjection.LoadInitialModelData(this.View.Model);
		}
	}

	[PresenterBinding(typeof(CustomizationPresenter))]
	public partial class Customization : DemoViewPage<CustomizationModel>, ICustomizationView
	{
		public override string Description
		{
			get { return "An overview of how the model injection process can be customized."; }
		}
		

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			this.lblOutput.Text +=
				"First Model Reports: " +
					((this.Model.First != null) ? this.Model.First.Length.ToString() + " Items" : "No Items");
			this.lblOutput.Text += "<br/>";

			this.lblOutput.Text +=
				"Second Model Reports: " +
					((this.Model.SecondInjection != null) ? this.Model.SecondInjection.Length.ToString() + " Items" : "No Items");
			this.lblOutput.Text += "<br/>";

			this.lblOutput.Text +=
				"Third Model Reports: " +
					((this.Model.Third != null) ? this.Model.Third.Length.ToString() + " Items" : "No Items");
			this.lblOutput.Text += "<br/>";

			this.lblOutput.Text +=
				"Second Model Reports: " +
					((this.Model.FourthInjection != null) ? this.Model.FourthInjection.Length.ToString() + " Items" : "No Items");
		}
	}
}