using System;
using UnityEngine;

namespace Labyrinth
{

    public abstract class InteractiveObject : MonoBehaviour, IDisposable
    {
        public abstract InteractiveObjectEnum Type { get; }
        public event Action<InteractiveObject> OnInteraction;
        public bool IsInteracted { get; private set; }
        public virtual void Interaction()
        {
            OnInteraction?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsInteracted || !other.CompareTag("Player"))
                return;

            Interaction();
            Dispose();
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}

