using Plugins.Modern.DI.App;
using Plugins.Modern.DI.Units;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plugins.Modern.DI.Setups {
	[CreateAssetMenu(menuName = "AppSetup", fileName = "AppSetup")]
	public class AppSetup : ScriptableObject {
		public AppComponentsRegistry appComponentsRegistry { get; } = new();

		[FormerlySerializedAs("units")]
		[SerializeField]
		private AppUnit[] _units;
		
		public static AppSetup liveInstance { get; private set; }
		
		public void RegisterSetup () {
			liveInstance = this;
			
			foreach (var appUnit in _units) {
				appUnit.SetupUnit(appComponentsRegistry);
			}
		}

		public void RegisterDestroy () {
			foreach (var item in appComponentsRegistry.items) {
				if (item is IDisposable disposable) {
					disposable.Dispose();
				}
			}
		}
	}
}
