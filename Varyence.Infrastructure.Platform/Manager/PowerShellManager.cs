using System.Linq;
using System.Management.Automation;

namespace Varyence.Infrastructure.Platform.PowerShellManager {
	public static class PowerShellManager {

		public static string Execute(string script) {
			string stringResult = string.Empty;
			using (PowerShell powerShellInstance = PowerShell.Create()) {
				powerShellInstance.AddScript(script);
				stringResult = powerShellInstance.Invoke().FirstOrDefault().ToString();
			}
			return stringResult;
		}
	}
}
