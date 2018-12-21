using System.Configuration;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace Varyence.Infrastructure.Service {
	public class BaseInstaller : Installer {

		public BaseInstaller() {
			Assembly assembly = Assembly.GetCallingAssembly();
			Configuration config = ConfigurationManager.OpenExeConfiguration(assembly.Location);
			ServiceConfigManager.LoadConfiguration(config);
			Installers.Add(new ServiceProcessInstaller() {
				Account = ServiceAccount.LocalSystem
			});
			Installers.Add(new ServiceInstaller() {
				StartType = ServiceStartMode.Automatic,
				ServiceName = ServiceConfigManager.ServiceName,
				DisplayName = ServiceConfigManager.ServiceDisplayName,
				Description = ServiceConfigManager.ServiceDescription
			});
		}
	}
}
 