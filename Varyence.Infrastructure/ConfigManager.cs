using System.Collections.Specialized;
using System.Configuration;

namespace Varyence.Infrastructure {
	public static class ConfigManager {

		private static readonly string _applicationName;
		private static readonly string _enviromentName;
		private static readonly string _webApiHost;

		static ConfigManager() {
			AppSettings = new NameValueCollection(ConfigurationManager.AppSettings);
			_applicationName = AppSettings["ApplicationName"];
			_enviromentName = AppSettings["EnviromentName"];
			_webApiHost = AppSettings["WebApiHost"];
		}

		public static NameValueCollection AppSettings;

		public static string ApplicationName => _applicationName;

		public static string EnviromentName => _enviromentName;

		public static string WebApiHost => _webApiHost;
	}
}
