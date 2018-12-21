namespace Varyence.DomainValue {
	public static class DOM {

		public static class PowerShellScript {

			public const string GetFreeSpaceOfDiscC = "(Get-PSDRIVE C|Select-Object Free).Free/(1024*1024)";
			public const string GetComputerName = "$Env:Computername";
		}
	}
}
