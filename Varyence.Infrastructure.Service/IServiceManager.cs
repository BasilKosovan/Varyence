namespace Varyence.Infrastructure.Service {

	public interface IServiceManager {

		void Process();
		object GetRequestModel();
	}
}
