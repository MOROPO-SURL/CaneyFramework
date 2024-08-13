namespace MOROPO.Framework.Caney.MVVM.Core.Models.Page
{
    public class BasePageModel : BaseBindableModel
    {
        protected bool busy;
        private string busyProgressMessage;

        public bool IsBusy
        {
            get { return busy; }
            set { SetProperty(ref busy, value); }
        }

        public string BusyProgressMessage
        {
            get => busyProgressMessage;
            set => SetProperty(ref busyProgressMessage, value);
        }
    }
}
