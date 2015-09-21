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

var userName = "haacked";
var client = new GitHubClient(new Octokit.ProductHeaderValue("Bay.NET"));

var repositories = await client.Repository.GetAllForUser(userName);
repositories.Select(r => new { r.Name }).Dump();

// basic authentication
//client.Credentials = new Credentials("username", "password");

// or if you don't want to give an app your creds
// you can use a token from an OAuth app
// Here is the URL to get tokens https://github.com/settings/tokens
// and save the token using Util.SetPassword("github","CHANGETHIS")
client.Credentials = new Credentials(Util.GetPassword("github"));

// and then fetch the repositories for the current user
var repos = await client.Repository.GetAllForCurrent();
repos.Select(r => r.Name).Dump();