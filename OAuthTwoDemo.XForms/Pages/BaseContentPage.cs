using Xamarin.Forms;

namespace OAuthTwoDemo.XForms
{
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsAuthenticated) {
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}

