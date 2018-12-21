using System;
using Varyence.Infrastructure;
using Varyence.Infrastructure.Platform;

namespace Varyence.Service.ApiCaller {
	static class Program {

		static void Main() {
			Bootstrapper.Initialize();
			var apiCallerService = DependencyResolverConfig.Resolve<ApiCallerService>();
#if DEBUG
			Console.WriteLine(ServiceConfigManager.ServiceName);
			Console.WriteLine(">> Service is starting... Press any key for exit.");
			apiCallerService.DebugStart();
			Console.ReadKey();
			Console.WriteLine(">> Service is stopping.");
			apiCallerService.Stop();
#else
			ServiceBase.Run(apiCallerService);
#endif
		}
	}
}
