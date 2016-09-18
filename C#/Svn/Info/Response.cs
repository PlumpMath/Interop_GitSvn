namespace Svn.Info
{
  public class Response
  {
    #region Mandatory
    public string Path { get; internal set; }
    public string URL { get; internal set; }
    public string RelativeURL { get; internal set; }
    public string RepositoryRoot { get; internal set; }
    public string RepositoryUUID { get; internal set; }
    public string Revision { get; internal set; }
    public string NodeKind { get; internal set; }
    public string LastChangedAuthor { get; internal set; }
    public string LastChangedRev { get; internal set; }
    public string LastChangedDate { get; internal set; }
    #endregion

    #region Optional
    public string WorkingCopyRootPath { get; internal set; }
    public string Schedule { get; internal set; }
    #endregion
  }
}
