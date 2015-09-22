<Query Kind="Statements">
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

var userName = "haacked";

var client = new GitHubClient(new Octokit.ProductHeaderValue("Bay.NET"));
client.Credentials = new Credentials(Util.GetPassword("github"));

var observableclient = new ObservableGitHubClient(client);

var gists = await observableclient.Gist.GetAllForUser(userName).Dump();

//Create A gist
var gist = new NewGist() { Description = "Gist from LinqPad", Public = true};
gist.Files.Add("test","Test file");

//Star a gist
var createdgist = await observableclient.Gist.Create(gist);
await observableclient.Gist.Star(createdgist.Id);

// Add a comment to the gist
var comment = await observableclient.Gist.Comment.Create(createdgist.Id,"Comment from linqpad").Dump();

