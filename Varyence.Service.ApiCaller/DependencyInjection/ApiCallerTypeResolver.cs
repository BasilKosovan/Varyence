using Unity;
using Varyence.Infrastructure.Platform;
using Varyence.Infrastructure.Service;

namespace Varyence.Service.ApiCaller.DependencyInjection {

	class ApiCallerTypeResolver : ITypeResolver {
		public void RegisterType(IUnityContainer container) {

			container.RegisterType<IServiceManager, ApiCallerServiceManager>();
		}
	}
}
