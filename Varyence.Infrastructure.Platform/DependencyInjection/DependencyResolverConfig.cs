using System.Linq;
using Unity;
using Unity.Interception.ContainerIntegration;

namespace Varyence.Infrastructure.Platform {

	public static class DependencyResolverConfig {

		private static IUnityContainer _container;

		public static IUnityContainer Container {
			get {
				return _container;
			}
		}

		public static void RegisterType(params ITypeResolver[] typeResolvers) {
			_container = BuildUnityContainer(typeResolvers);
		}

		public static IUnityContainer BuildUnityContainer(params ITypeResolver[] typeResolvers) {
			var container = new UnityContainer();
			container.AddNewExtension<Interception>();
			if (typeResolvers != null && typeResolvers.Any()) {
				foreach (var typeResolver in typeResolvers) {
					typeResolver.RegisterType(container);
				}
			}
			return container;
		}

		public static T Resolve<T>() {
			return _container.Resolve<T>();
		}
	}
}
