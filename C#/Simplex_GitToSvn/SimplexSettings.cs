using InfraStructure;

namespace Simplex_GitToSvn
{
  internal class SimplexSettings : AppSettings
  {
    public static string SvnRemoteUrl { get { return Get<string>("SvnRemoteUrl"); } }
    public static string GitRemoteUrl { get { return Get<string>("GitRemoteUrl"); } }
    public static string LocalPath { get { return Get<string>("LocalPath"); } }
  }
}
