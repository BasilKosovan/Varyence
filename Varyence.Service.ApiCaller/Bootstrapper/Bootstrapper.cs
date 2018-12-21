using Varyence.Infrastructure.Platform;
using Varyence.Service.ApiCaller.DependencyInjection;

namespace Varyence.Service.ApiCaller {
	public static class Bootstrapper {

		public static void Initialize() {

			DependencyResolverConfig.RegisterType(
				new ApiCallerTypeResolver()
			);
		}
	}
}
