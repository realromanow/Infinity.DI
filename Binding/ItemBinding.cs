using UniRx;
using UnityEngine;

namespace Plugins.Modern.DI.Binding {
	public class ItemBinding<TItem> : MonoBehaviour {
		public TItem item { get; private set; }
		public string itemId { get; private set; }

		protected readonly CompositeDisposable bindingDisposable = new();

		private void OnDestroy () {
			RegisterDestroy();
		}

		protected virtual void RegisterInitialize () {}

		protected virtual void RegisterDestroy () {
			bindingDisposable.Dispose();
		}

		public void SetItem (TItem itemModel, string id) {
			item = itemModel;
			itemId = id;

			RegisterInitialize();
		}
	}
}
