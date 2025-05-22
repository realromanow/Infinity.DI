using Plugins.Modern.DI.Setups;
using UnityEngine;

namespace Plugins.Modern.DI.App {
	public class ModernAppSetupRegistry : MonoBehaviour {
		[SerializeField]
		private ModernAppSetup _setup;

		private void Awake () {
			_setup.RegisterSetup();
		}

		private void OnDestroy () {
			_setup.RegisterDestroy();
		}
	}
}
