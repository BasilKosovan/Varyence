using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Varyence.Infrastructure.Platform;
using Timer = System.Timers.Timer;

namespace Varyence.Infrastructure.Service {
	public abstract class BaseService : ServiceBase {

		protected readonly IServiceManager _serviceManager;
		protected readonly Timer _batchTimer;

		public BaseService(IServiceManager serviceManager) {
			_serviceManager = serviceManager;
			ServiceName = ServiceConfigManager.ServiceName;
			_batchTimer = new Timer(ServiceConfigManager.IntervalInSeconds*1000);
			_batchTimer.Elapsed += BatchTimerOnElapsed;
		}

#if DEBUG
		public void DebugStart() {
			OnStart(null);
		}
#endif

		protected override void OnStart(string[] args) {
			_batchTimer.Start();
		}

		protected override void OnStop() {
			RequestAdditionalTime(1000);
			_batchTimer.Stop();
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				DependencyResolverConfig.Container.Dispose();
				_batchTimer.Dispose();
			}
			base.Dispose(disposing);
		}

		private void BatchTimerOnElapsed(object sender, ElapsedEventArgs e) {
			try {
				Task.Factory.StartNew(_serviceManager.Process, CancellationToken.None);
			} catch (Exception ex) {
				//TODO: LOG
			}
		}
	}
}
