<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>Octokit</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

var owner = "octokit";
var reponame = "octokit.net";
var client = new GitHubClient(new Octokit.ProductHeaderValue("Bay.NET"));

//Get releases for the octokit
var releases = await client.Release.GetAll("octokit", "octokit.net");
releases.Select(r => new { r.Name, r.Body }).Dump("Releases");

//Don't want draft release and because we are using reactive the first one is the latest one.
var latestrelease = releases.First(r => r.Draft == false).Dump("Latest Octokit"); 

//Gets the assets for the latest relase
var assets = await client.Release.GetAllAssets(owner,reponame,latestrelease.Id);
assets.Dump("Assets");
var latestreleaseassetid = assets.First(a => a.Name.Contains("Reactive")).Id;
var asset = await client.Release.GetAsset(owner,reponame,latestreleaseassetid);

//Download the release
var wc = new WebClient();
var filename = Path.Combine( Path.GetTempPath(),"Octokit-Reactive.nupkg"); 
await wc.DownloadFileTaskAsync(asset.BrowserDownloadUrl,filename);
filename.Dump();