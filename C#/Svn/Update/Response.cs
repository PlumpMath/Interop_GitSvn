using System;

namespace Svn.Update
{
  public class Response
  {
    public string Changes { get; internal set; }
    public bool Success { get; internal set; }
  }
}
