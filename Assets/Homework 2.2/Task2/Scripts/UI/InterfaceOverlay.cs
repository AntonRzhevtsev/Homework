using UnityEngine;

namespace Homework2_2Task_2
{
    public abstract class InterfaceOverlay : MonoBehaviour
    {
        public virtual void Hide() => gameObject.SetActive(false);

        public virtual void Show() => gameObject.SetActive(true);
    }
}