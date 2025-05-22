using Plugins.Modern.DI.App;
using Plugins.Modern.DI.Units;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plugins.Modern.DI.Setups {
	[CreateAssetMenu(menuName = "AppSetup", fileName = "AppSetup")]
	public class ModernAppSetup : ScriptableObject {
		public ModernComponentsRegistry modernComponentsRegistry { get; } = new();

		[FormerlySerializedAs("units")]
		[SerializeField]
		private ModernAppUnit[] _units;
		
		public static ModernAppSetup liveInstance { get; private set; }
		
		public void RegisterSetup () {
			liveInstance = this;
			
			foreach (var appUnit in _units) {
				appUnit.SetupUnit(modernComponentsRegistry);
			}
		}

		public void RegisterDestroy () {
			foreach (var item in modernComponentsRegistry.items) {
				if (item is IDisposable disposable) {
					disposable.Dispose();
				}
			}
		}
	}
}
