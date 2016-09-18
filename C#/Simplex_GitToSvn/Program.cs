namespace Simplex_GitToSvn
{
#if DEBUG
  using System;

  static class Program
  {
    static void Main()
    {
      var scope = new SimplexScope();
      scope.Execute();

      Console.WriteLine("Press any key to close this application");
      Console.ReadKey();
    }
  }
#else
  //using System.ServiceProcess;

  //static class Program
  //{
  //  /// <summary>
  //  /// The main entry point for the application.
  //  /// </summary>
  //  static void Main()
  //  {
  //    ServiceBase[] ServicesToRun;
  //    ServicesToRun = new ServiceBase[] 
  //          { 
  //              new Service1() 
  //          };
  //    ServiceBase.Run(ServicesToRun);
  //  }
  //}
#endif
}