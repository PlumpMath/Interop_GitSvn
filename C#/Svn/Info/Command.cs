namespace Svn.Info
{
  public class Command
  {
    public Response Execute()
    {
      var command = "svn info";
    }

    public Response Execute(string path)
    {
      var command = "svn info {0}";
    }
  }
}
