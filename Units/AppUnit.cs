using Plugins.Infinity.DI.App;
using UnityEngine;

namespace Plugins.Infinity.DI.Units {
	public class AppUnit : ScriptableObject {
		public virtual void SetupUnit (AppComponentsRegistry componentsRegistry) { }
	}
}
