namespace CaseTestingApp.Pages;

public partial class ViewsPage : ContentPage
{
	public ViewsPage()
	{
		InitializeComponent();

		BindingContext = new MOROPO.Framework.Caney.MVVM.Core.Models.Page.BasePageModel { IsBusy = true };
	}
}