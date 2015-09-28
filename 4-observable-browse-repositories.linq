<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	var owner = string.Empty;
	
	#if CMD
		owner = args[0];
	#else
		owner = "octokit";
	#endif
	
	var client = new ObservableGitHubClient(new Octokit.ProductHeaderValue("Octokit.samples"));
	client.Repository.GetAllForUser(owner).Select(r => r.Name).Dump();
}

