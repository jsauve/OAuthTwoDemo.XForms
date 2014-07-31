using System; 
using Android.App;
using OAuthTwoDemo.XForms;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using OAuthTwoDemo.XForms.Android;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace OAuthTwoDemo.XForms.Android
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnModelChanged (VisualElement oldModel, VisualElement newModel)
		{
			base.OnModelChanged (oldModel, newModel);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator (
				clientId: App.Instance.OAuthSettings.ClientId, // your OAuth2 client id
				scope: App.Instance.OAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri (App.Instance.OAuthSettings.AuthorizeUrl), // the auth URL for the service
				redirectUrl: new Uri (App.Instance.OAuthSettings.RedirectUrl)); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated) {
					App.Instance.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
				} else {
					// The user cancelled
				}
			};

			activity.StartActivity (auth.GetUI(activity));
		}
	}
}