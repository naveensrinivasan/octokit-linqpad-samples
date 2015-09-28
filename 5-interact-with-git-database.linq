<Query Kind="Program">
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main(string[] args)
{
	var owner = string.Empty;
	var reponame = string.Empty;
	
	#if CMD
		owner = args[0];
		reponame = args[1];
	#else
		owner = "octokit";
		reponame = "octokit.net";
	#endif
	
	var client = new GitHubClient(new Octokit.ProductHeaderValue("Octokit.samples"));
	var releases = await client.Release.GetAll(owner, reponame);
	
	// we have to build up this tag because release tags
	// are just lightweight tags. you can read more about
	// the differences between lightweight tags and annotated tags
	// here: http://git-scm.com/book/en/Git-Basics-Tagging#Creating-Tags
	
	// we can fetch the tag for this release
	var reference = "tags/" + releases[0].TagName;
	var tag = await client.GitDatabase.Reference.Get("octokit", "octokit.net", reference);
	tag.Dump();
	
	// and we can fetch the commit associated with this release
	var commit = await client.GitDatabase.Commit.Get("octokit", "octokit.net", tag.Object.Sha);
	commit.Dump();
}