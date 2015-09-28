<Query Kind="Program">
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main(string[] args)
{
		var userName = string.Empty;
		#if CMD
			userName = args[0];
		#else
			userName = "naveensrinivasan";
		#endif
		
		var client = new GitHubClient(
			new Octokit.ProductHeaderValue("octokit.samples"));
		
		var repositories = await client.Repository.GetAllForUser(userName);
		repositories.Select(r => new { r.Name }).Dump(userName + "Repos");
		
		// basic authentication
		//client.Credentials = new Credentials("username", "password");
		
		// or if you don't want to give an app your creds
		// you can use a token from an OAuth app
		// Here is the URL to get tokens https://github.com/settings/tokens
		// and save the token using Util.SetPassword("github","CHANGETHIS")
		client.Credentials = new Credentials(Util.GetPassword("github"));
		
		// and then fetch the repositories for the current user
		var repos = await client.Repository.GetAllForCurrent();
		repos.Select(r => r.Name).Dump("Your Repos");
	
	
	// Define other methods and classes here
	
}

// Define other methods and classes here
