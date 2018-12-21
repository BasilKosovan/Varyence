using RestSharp;

namespace Varyence.Infrastructure.Platform.RestApiManager {
	public class RestApiManager {

		private readonly RestClient _client;

		public RestApiManager(string host) {
			_client = new RestClient(host);
		}

		public void Execute(object requestModel) {
			var request = new RestRequest("/log", Method.POST);
			request.AddJsonBody(requestModel);
			_client.ExecuteAsync(request, null);
		}
	}
}
