using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Infinity.DI.Binding {
	public class ItemBinding<TItem> : MonoBehaviour {
		public TItem item { get; private set; }
		public string itemId { get; private set; }

		private readonly List<Action> _subscriptions = new();
		
		private event Action onDataUpdate;
		
		private void OnDestroy () {
			RegisterDestroy();
		}

		protected virtual void RegisterInitialize () {
			onDataUpdate += OnUpdate;
		}

		protected virtual void RegisterDestroy () {
			foreach (var subscription in _subscriptions) {
				onDataUpdate -= subscription;
			}
			
			onDataUpdate -= OnUpdate;
		}
		
		protected virtual void OnUpdate() {}

		public void SetItem (TItem itemModel, string id) {
			this.item = itemModel;
			this.itemId = id;

			RegisterInitialize();
			OnUpdate();
		}
		
		protected void SubscribeToUpdate (Action action) {
			_subscriptions.Add(action);
			
			action += onDataUpdate;
		}
	}
}
