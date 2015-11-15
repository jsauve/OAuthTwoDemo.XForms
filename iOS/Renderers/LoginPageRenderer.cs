﻿using System;
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

		bool IsShown;

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// Fixed the issue that on iOS 8, the modal wouldn't be popped.
			// url : http://stackoverflow.com/questions/24105390/how-to-login-to-facebook-in-xamarin-forms
			if(	! IsShown ) {

				IsShown = true;

				var auth = new OAuth2Authenticator (
					clientId: App.Instance.OAuthSettings.ClientId, // your OAuth2 client id
					scope: App.Instance.OAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri (App.Instance.OAuthSettings.AuthorizeUrl), // the auth URL for the service
					redirectUrl: new Uri (App.Instance.OAuthSettings.RedirectUrl)); // the redirect URL for the service




				auth.Completed += (sender, eventArgs) => {
					// We presented the UI, so it's up to us to dimiss it on iOS.
					DismissViewController (true, null);
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
}

