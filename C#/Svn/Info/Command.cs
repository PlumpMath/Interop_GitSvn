using System;
using InfraStructure;

namespace Svn.Info
{
  public class Command
  {
    public Response Execute(string path)
    {
      var command = string.Format("svn info {0}", path);
      return Interpret(Shell.Execute(command));
    }

    private Response Interpret(string value)
    {
      var splitted = value.Split(new[] {"\r\n"}, StringSplitOptions.None);
      var response = new Response();
      foreach (var item in splitted)
      {
        var split = item.Split(new[] { ':' }, StringSplitOptions.None);
        var removePattern = string.Concat(split[0], ": ");

        switch (split[0])
        {
          case "Path":
            response.Path = item.Replace(removePattern, "");
            break;
          case "URL":
            response.URL = item.Replace(removePattern, "");
            break;
          case "Relative URL":
            response.RelativeURL = item.Replace(removePattern, "");
            break;
          case "Repository Root":
            response.RepositoryRoot = item.Replace(removePattern, "");
            break;
          case "Repository UUID":
            response.RepositoryUUID = item.Replace(removePattern, "");
            break;
          case "Revision":
            response.Revision = Convert.ToInt64(item.Replace(removePattern, ""));
            break;
          case "Node Kind":
            response.NodeKind = item.Replace(removePattern, "");
            break;
          case "Last Changed Author":
            response.LastChangedAuthor = item.Replace(removePattern, "");
            break;
          case "Last Changed Rev":
            response.LastChangedRev = Convert.ToInt64(item.Replace(removePattern, ""));
            break;
          case "Last Changed Date":
            response.LastChangedDate = Convert.ToDateTime(item.Replace(removePattern, "").Substring(0,25));
            break;



          case "Working Copy Root Path":
            response.WorkingCopyRootPath = item.Replace(removePattern, "");
            break;
          case "Schedule":
            response.Schedule = item.Replace(removePattern, "");
            break;
        }
      }

      return response;
    }
  }
}
