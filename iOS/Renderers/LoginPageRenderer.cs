using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using OAuthTwoDemo.XForms;
using OAuthTwoDemo.XForms.iOS;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace OAuthTwoDemo.XForms.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			var auth = new OAuth2Authenticator (
				clientId: "", // your OAuth2 client id
				scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri (""), // the auth URL for the service
				redirectUrl: new Uri ("")); // the redirect URL for the service

				// if you're looking for more info on OAuth2, I like how Instagram's docs describe it: http://instagram.com/developer/authentication/

			auth.Completed += (sender, eventArgs) => {
				// We presented the UI, so it's up to us to dimiss it on iOS.
				App.Instance.SuccessfulLoginAction.Invoke();

				if (eventArgs.IsAuthenticated) {
					// Use eventArgs.Account to do wonderful things
					App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
				} else {
					// The user cancelled
				}
			};

			PresentViewController (auth.GetUI (), true, null);
		}
	}
}

