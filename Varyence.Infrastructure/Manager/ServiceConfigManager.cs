using System.Configuration;

namespace Varyence.Infrastructure {
	public static class ServiceConfigManager {

		private static string _serviceName;
		private static string _serviceDisplayName;
		private static string _serviceDescription;
		private static int _intervalInSeconds;

		static ServiceConfigManager() {
			_serviceName = ConfigManager.AppSettings["ServiceName"];
			_serviceDisplayName = ConfigManager.AppSettings["ServiceDisplayName"];
			_serviceDescription = ConfigManager.AppSettings["ServiceDescription"];

			if (!int.TryParse(ConfigManager.AppSettings["IntervalInSeconds"], out _intervalInSeconds))
				_intervalInSeconds = 30;
		}

		public static string ServiceName {
			get {
				return _serviceName;
			}
		}

		public static string ServiceDisplayName {
			get {
				return _serviceDisplayName;
			}
		}

		public static string ServiceDescription {
			get {
				return _serviceDescription;
			}
		}


		public static int IntervalInSeconds {
			get {
				return _intervalInSeconds;
			}
		}

		public static void LoadConfiguration(Configuration config) {
			_serviceName = config.AppSettings.Settings["ServiceName"].Value;
			_serviceDisplayName = config.AppSettings.Settings["ServiceDisplayName"].Value;
			_serviceDescription = config.AppSettings.Settings["ServiceDescription"].Value;
		}
	}
}
