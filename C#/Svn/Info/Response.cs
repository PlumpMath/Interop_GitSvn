using System;

namespace Svn.Info
{
  public class Response
  {
    public string Path { get; internal set; }
    public string URL { get; internal set; }
    public string RelativeURL { get; internal set; }
    public string RepositoryRoot { get; internal set; }
    public string RepositoryUUID { get; internal set; }
    public long Revision { get; internal set; }
    public string NodeKind { get; internal set; }
    public string LastChangedAuthor { get; internal set; }
    public long LastChangedRev { get; internal set; }
    public DateTime LastChangedDate { get; internal set; }


    #region Optional
    public string WorkingCopyRootPath { get; internal set; }
    public string Schedule { get; internal set; }
    #endregion
  }
}
