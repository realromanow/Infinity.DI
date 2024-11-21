using Plugins.Modern.DI.Setups;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plugins.Modern.DI.App {
	public class AppSetupRegistry : MonoBehaviour {
		[FormerlySerializedAs("setup")]
		[SerializeField]
		private AppSetup _setup;

		private void Awake () {
			_setup.RegisterSetup();
		}

		private void OnDestroy () {
			_setup.RegisterDestroy();
		}
	}
}
