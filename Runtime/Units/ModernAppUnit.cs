using Plugins.Modern.DI.App;
using UnityEngine;

namespace Plugins.Modern.DI.Units {
	public class ModernAppUnit : ScriptableObject {
		public virtual void SetupUnit (ModernComponentsRegistry componentsRegistry) {}
	}
}
