using Plugins.Modern.DI.App;
using UnityEngine;

namespace Plugins.Modern.DI.Units {
	public class AppUnit : ScriptableObject {
		public virtual void SetupUnit (AppComponentsRegistry componentsRegistry) { }
	}
}
