<Query Kind="Statements">
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var owner = "torvalds";


var client = new GitHubClient(new Octokit.ProductHeaderValue("Bay.NET"));
client.Credentials = new Credentials(Util.GetPassword("github"));

var reactivessh = new ObservableSshKeysClient(client);
var followers = new  ObservableFollowersClient(client);

reactivessh.GetAll(owner).Dump();
//another reason for having a reactive client
followers.GetAll(owner).Dump();