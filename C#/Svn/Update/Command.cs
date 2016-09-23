using System;
using System.Linq;
using System.Text;
using InfraStructure;

namespace Svn.Update
{
  public class Command
  {
    public Response Execute(Encoding encoding, string path, long revision)
    {
      var command = string.Format("svn update {0} -r {1}", path, revision);
      return Interpret(Shell.Execute(command, encoding));
    }

    private Response Interpret(string value)
    {
      var splitted = value.Split(new[] { "\r\n" }, StringSplitOptions.None);
      Response response = new Response();

      for (int i = 2; i < splitted.Length - 1; i++)
        response.Changes += string.IsNullOrWhiteSpace(response.Changes) ? splitted[i] : string.Concat("\r\n", splitted[i]);
      response.Success = splitted.Last().Contains("Updated to revision");

      return response;
    }
  }
}
