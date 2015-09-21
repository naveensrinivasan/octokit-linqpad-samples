<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

var owner = "octokit";
var reponame = "octokit.net";

var client = new GitHubClient(new Octokit.ProductHeaderValue("octokit samples"));

var repository = await client.Repository.Get(owner, reponame);

Console.WriteLine(String.Format("Octokit.net can be found at {0}\n", repository.HtmlUrl));

Console.WriteLine("It currently has {0} watchers and {1} forks\n", 
	repository.StargazersCount,
    repository.ForksCount);

Console.WriteLine("It has {0} open issues\n", repository.OpenIssuesCount);

Console.WriteLine("And GitHub thinks it is a {0} project", repository.Language);