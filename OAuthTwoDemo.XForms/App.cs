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
						if (_Instance == null) 
							_Instance = new App();
					}
				}

				return _Instance;
			}
		}

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

