using System;
using System.Diagnostics;
using System.Text;

namespace InfraStructure
{
  public class Shell
  {
    public static string Execute(string value, Encoding encoding = null)
    {
      var cmd = new Process();
      cmd.StartInfo.FileName = "cmd.exe";
      cmd.StartInfo.RedirectStandardInput = true;
      cmd.StartInfo.RedirectStandardOutput = true;
      cmd.StartInfo.CreateNoWindow = true;
      cmd.StartInfo.UseShellExecute = false;
      cmd.StartInfo.StandardOutputEncoding = encoding ?? Encoding.Default;
      cmd.Start();

      cmd.StandardInput.WriteLine(value);
      cmd.StandardInput.Flush();
      cmd.StandardInput.Close();
      cmd.WaitForExit();

      var output = cmd.StandardOutput.ReadToEnd();
      var splitted = output.Split(new[] { "\r\n" }, StringSplitOptions.None);

      var returnValue = string.Empty;

      for (int i = 4; i <= splitted.Length - 3; i++)
        returnValue = string.Format("{0}\r\n{1}", returnValue, splitted[i]);

      return returnValue;
    }
  }
}