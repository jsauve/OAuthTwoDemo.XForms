using System;
using Xamarin.Forms;

namespace OAuthTwoDemo.XForms
{
	public class App
	{
		// just a singleton pattern so I can have the concept of an app instance
		static volatile App _Instance;
		static object _SyncRoot = new Object();
		public static App Instance
		{
			get 
			{
				if (_Instance == null) 
				{
					lock (_SyncRoot) 
					{
						if (_Instance == null) {
							_Instance = new App ();
							_Instance.OAuthSettings = 
								new OAuthSettings (
									clientId: "3b523a97d57e428488da56ad80789119",  // your OAuth2 client id 
									scope: "basic",  // The scopes for the particular API you're accessing. The format o this will vary by API.
									authorizeUrl: "https://instagram.com/oauth/authorize",  // the auth URL for the service
									redirectUrl: "http://www.joesauve.com/using-xamarin-auth-with-xamarin-forms/"); // the redirect URL for the service
						}
					}
				}

				return _Instance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

		NavigationPage _NavPage;

		public Page GetMainPage ()
		{
			var profilePage = new ProfilePage();

			_NavPage = new NavigationPage(profilePage);

			return _NavPage;
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		string _Token;
		public string Token {
			get { return _Token; }
		}

		public void SaveToken(string token)
		{
			_Token = token;

			// broadcast a message that authentication was successful
			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => _NavPage.Navigation.PopModalAsync ());
			}
		}
	}
}

