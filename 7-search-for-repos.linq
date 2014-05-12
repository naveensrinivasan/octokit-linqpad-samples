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

//This makes discovering code fun!!
var client = new GitHubClient(new Octokit.ProductHeaderValue("Naveen"));
var gorepos = await client.Search.SearchRepo(new SearchRepositoriesRequest(string.Empty)
	{Language = Language.Go});
gorepos.Items.OrderByDescending (i => i.CreatedAt)
	.OrderByDescending (i => i.WatchersCount)
	.Take(50)
	.Select (i => new {
			Name = i.Name, 
			Description = i.Description ,
			LastUpdated = i.UpdatedAt,
			Url = i.HtmlUrl,
			WatchCount = i.WatchersCount
			})
	.Dump();

