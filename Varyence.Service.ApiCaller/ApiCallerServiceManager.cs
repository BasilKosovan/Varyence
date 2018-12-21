using System;
using Varyence.DomainValue;
using Varyence.Infrastructure;
using Varyence.Infrastructure.Platform.PowerShellManager;
using Varyence.Infrastructure.Platform.RestApiManager;
using Varyence.Infrastructure.Service;

namespace Varyence.Service.ApiCaller {
	class ApiCallerServiceManager : IServiceManager {

		private RestApiManager apiManager = new RestApiManager(ConfigManager.WebApiHost);

		public object GetRequestModel() {
			string diskCfreeSpace = PowerShellManager.Execute(DOM.PowerShellScript.GetFreeSpaceOfDiscC);
			string computerName = PowerShellManager.Execute(DOM.PowerShellScript.GetComputerName);
			string updateTimestamp = string.Format("{0:O}", DateTime.UtcNow);

			return new { Id = 1, updateTimestamp, computerName, diskCfreeSpace };
		}

		public void Process() {
			apiManager.Execute(GetRequestModel());
		}
	}
}
