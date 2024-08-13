namespace MOROPO.Framework.Caney.MVVM.Core.Pages
{
    public class BindingContextedContentPage<TPageModel> : ContentPage where TPageModel : Models.Page.BasePageModel
    {
        public BindingContextedContentPage(TPageModel pageModel)
        {
            BindingContext = pageModel;
        }

        public TPageModel BindingContextPageModel { get => BindingContext as TPageModel; }
    }
}
