## A simple demo of Xamarin.Auth in Xamarin.Forms

This demo does not cover pulling back any profile data (or any other data) from your given auth provider's API (Facebook, Instagram, Twitter, Google, etc, etc, etc), but it will get you authenticated. After successful authentication, it's up to you to make subsequent calls against your chosen API with the auth token you receive.

### Edit the App.cs class in the core project:
You'll need to edit the following in the App.cs in order to get it to work with your OAuth provider:

    _Instance.OAuthSettings = 
        new OAuthSettings (
            clientId: "",  // your OAuth2 client id 
            scope: "",  // The scopes for the particular API you're accessing. The format for this will vary by API.
            authorizeUrl: "",  // the auth URL for the service
            redirectUrl: ""); // the redirect URL for the service

### What you get:

![Xamarin.Auth with Xamarin.Forms iOS example](http://www.joesauve.com/content/images/2014/Jun/XamarinAuthXamarinFormsExample-1.gif)
![Xamarin.Auth with Xamarin.Forms Android example](http://www.joesauve.com/content/images/2014/Jun/Xamarin-Auth_Xamarin-Forms_example_Android.gif)
