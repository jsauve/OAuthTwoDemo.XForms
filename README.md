## A simple demo of Xamarin.Auth in Xamarin.Forms

This demo does not cover pulling back any profile data (or any other data) from your given auth provider's API (Facebook, Instagram, Twitter, Google, etc, etc, etc), but it will get you authenticated. After authentication, it's up to you to make subsequent calls against your chosen API with the token you received from the successful authentication.

### Edit the two LoginPageRenderer classes
You'll need to edit the follow in the LoginPageRenderer class of both the iOS and Android projects in order to get it to work with your OAuth provider:

    var auth = new OAuth2Authenticator (
        clientId: "", // your OAuth2 client id
        scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
        authorizeUrl: new Uri (""), // the auth URL for the service
        redirectUrl: new Uri ("")); // the redirect URL for the service
        
Could this have been put in a common place so as not to be dupplicated in both files? Yeah, probably.

### What you get:

![Xamarin.Auth with Xamarin.Forms iOS example](http://www.joesauve.com/content/images/2014/Jun/XamarinAuthXamarinFormsExample-1.gif)
![Xamarin.Auth with Xamarin.Forms Android example](http://www.joesauve.com/content/images/2014/Jun/Xamarin-Auth_Xamarin-Forms_example_Android.gif)
