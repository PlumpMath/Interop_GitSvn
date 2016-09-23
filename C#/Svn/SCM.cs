using System.Text;

namespace Svn
{
  public class SCM
  {
    public Encoding Encoding { get; private set; }
    
    public SCM(Encoding encoding)
    {
      Encoding = encoding;
    }

    public SCM() : this(Encoding.Default) { }
    

    public Info.Response Info(string path)
    {
      var command = new Info.Command();
      return command.Execute(path);
    }

    public Log.Response Log(string path)
    {
      var command = new Log.Command();
      return command.Execute(Encoding, path);
    }

    public Log.Response Log(string path, long revision)
    {
      var command = new Log.Command();
      return command.Execute(Encoding, path, revision);
    }

    public Update.Response Update(string path, long revision)
    {
      var command = new Update.Command();
      return command.Execute(Encoding, path, revision);
    }
  }
}
