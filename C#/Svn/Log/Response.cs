using System;

namespace Svn.Log
{
  public class Response
  {
    public long Revision { get; internal set; }
    public string Author { get; internal set; }
    public DateTime Date { get; internal set; }
    public string Message { get; internal set; }
  }
}
