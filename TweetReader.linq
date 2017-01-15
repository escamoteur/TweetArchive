<Query Kind="Program">
  <NuGetReference>BoxKite.Twitter</NuGetReference>
  <Namespace>BoxKite.Twitter</Namespace>
  <Namespace>BoxKite.Twitter.Authentication</Namespace>
  <Namespace>BoxKite.Twitter.Extensions</Namespace>
  <Namespace>BoxKite.Twitter.Helpers</Namespace>
  <Namespace>BoxKite.Twitter.Models</Namespace>
</Query>



void Main()
{
	
	
	var desktopPlatformAdaptor = new DesktopPlatformAdaptor();

	// Using consumerkey and consumersecret, start the OAuth1.0a process
	
	var session = new ApplicationSession("yourapikey","yourapisecret");
	
	var twitterauth = TwitterAuthenticator.StartApplicationOnlyAuth(session).Result;


	// if OK
	if (twitterauth)
	{
		var timeline =  session.GetUserTimeline("nytimes").Result;
		
		foreach (var tweet in timeline)
		{
			tweet.Dump();	
		}
	}
	else
	{
		System.Console.WriteLine(
			"Authenticator could not start. Do you have the correct Client/Consumer IDs and secrets?");
	}
}

// Define other methods and classes here
