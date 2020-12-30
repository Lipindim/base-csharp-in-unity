using System;
using UnityEngine;

namespace Labyrinth
{

    public abstract class InteractiveObject : MonoBehaviour, IDisposable
    {

        #region Fields

        public event Action<InteractiveObject> OnInteraction;

        #endregion


        #region Properties

        public abstract InteractiveObjectEnum Type { get; }
        public bool IsInteracted { get; private set; }

        #endregion


        #region Methods

        public virtual void Interaction()
        {
            OnInteraction?.Invoke(this);
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (IsInteracted || !other.CompareTag("Player"))
                return;

            Interaction();
            Dispose();
        }

        #endregion


        #region IDisposable

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }

        #endregion

    }
}

