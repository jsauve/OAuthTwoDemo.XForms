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
									clientId: "",  		// your OAuth2 client id 
									scope: "",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
									authorizeUrl: "",  	// the auth URL for the service
									redirectUrl: "");   // the redirect URL for the service

							        // If you'd like to know more about how to integrate with an OAuth provider, 
									// I personally like the Instagram API docs: http://instagram.com/developer/authentication/
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

