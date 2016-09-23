using System;
using System.Text;
using InfraStructure;

namespace Svn.Log
{
  public class Command
  {
    public Response Execute(Encoding encoding, string path)
    {
      var command = string.Format("svn log {0} -r BASE", path);
      return Interpret(Shell.Execute(command, encoding));
    }

    public Response Execute(Encoding encoding, string path, long revision)
    {
      var command = string.Format("svn log {0} -r {1}", path, revision);
      return Interpret(Shell.Execute(command, encoding));
    }

    private Response Interpret(string value)
    {
      var splitted = value.Split(new[] { "\r\n" }, StringSplitOptions.None);
      Response response = null;
      foreach (var item in splitted)
      {
        if (item.StartsWith("r") && response == null)
        {
          var split = item.Split(new[] { '|' }, StringSplitOptions.None);

          response = new Response();
          response.Revision = Convert.ToInt64(split[0].Trim().Substring(1));
          response.Author = split[1].Trim();
          response.Date = Convert.ToDateTime(split[2].Trim().Substring(0, 25));
        }
        else if (response != null && !string.IsNullOrWhiteSpace(item))
        {
          response.Message = string.IsNullOrWhiteSpace(response.Message) ? item.Trim() : string.Concat(response.Message, "\r\n", item.Trim());  
        }
      }

      return response;
    }
  }
}
