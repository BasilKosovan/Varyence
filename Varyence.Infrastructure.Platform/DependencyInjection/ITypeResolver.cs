using Unity;

namespace Varyence.Infrastructure.Platform {
	public interface ITypeResolver {

		void RegisterType(IUnityContainer container);
	}
}
