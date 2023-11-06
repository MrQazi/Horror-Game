    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public class ProxyCollider : MonoBehaviour {
        public UnityEvent<Collider> onTriggerEnter;
        public bool once;

        private void OnTriggerEnter(Collider other) {
            if(!enabled)return;
            if (!Player.Inst) return;
            if (other.transform != Player.Inst.transform) return;
            onTriggerEnter.Invoke(other);
            Destroy(gameObject);
        }
    }