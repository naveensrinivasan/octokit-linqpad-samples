<Query Kind="Program">
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	//Search Issues with xamarin keyword and get the results

	var owner = "octokit";
	var reponame = "octokit.net";
	var client = new GitHubClient(new Octokit.ProductHeaderValue("Bay.NET"));
	client.Credentials = new Credentials(Util.GetPassword("github"));
	
	
	var issue = new SearchIssuesRequest("xamarin");
	issue.Repos.Add(owner,reponame);
	issue.SortField = IssueSearchSort.Updated;
	var searchresults = await client.Search.SearchIssues(issue);
	
	//For every issue get the comments for it
	var commentsclient = client.Issue.Comment;
	var comments = searchresults.Items.Select(async i =>
									new { IssueNumber = i.Number, 
										Comments = await commentsclient
											.GetAllForIssue(owner, reponame, i.Number)});
	
	var issueComments = await Task.WhenAll( comments);
	
	
	//Combine the comments with Issue and then dump it.
	searchresults.Items.Select(i => new
	{
		Number = Util.RawHtml(new XElement("a", 
				new XAttribute("href", i.HtmlUrl.ToString()), i.Number)),
		i.Title,
		i.Body,
		i.State,
		Comments = issueComments.FirstOrDefault(c => c.IssueNumber == i.Number)
					.Comments.Select(c => 
					new { User = c.User.Id, 
						  Name = c.User.Name,  	
						   Content = c.Body, 
						   Date = c.CreatedAt, 
						   Id = c.Id, c.Body})
	} ).Dump();
}



// Define other methods and classes here