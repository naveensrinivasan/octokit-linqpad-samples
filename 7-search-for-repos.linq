<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>Octokit</Namespace>
</Query>

var client = new GitHubClient(new Octokit.ProductHeaderValue("Naveen"));
var gorepos = await client.Search.SearchRepo(new SearchRepositoriesRequest(string.Empty)
	{Language = Language.Go});
gorepos.Items.OrderByDescending (i => i.CreatedAt)
.Take(100)
.OrderByDescending (i => i.WatchersCount)
.Take(30)
.Dump();