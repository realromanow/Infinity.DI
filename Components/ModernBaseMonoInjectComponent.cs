using Plugins.Modern.DI.Setups;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Plugins.Modern.DI.Components {
	public abstract class ModernBaseMonoInjectComponent : MonoBehaviour {
		private void Start () {
			Inject(ModernAppSetup.liveInstance.modernComponentsRegistry.items);
		}

		private void Inject (params object[] args) {
			var mainType = this.GetType();
			var properties = mainType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

			foreach (var property in properties) {
				var targetType = property.FieldType;
				var targetArg = args.FirstOrDefault(x => targetType.IsInstanceOfType(x));
				
				if (targetArg != null) property.SetValue(this, targetArg);
			}
		}
	}
}
