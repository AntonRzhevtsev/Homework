using System;
using UnityEngine;

namespace Homework2_2Task_2
{
    public class InputManager : MonoBehaviour
    {
        public event Action DamagePlayer;
        public event Action HealPlayer;
        public event Action GiveExperienceToPlayer;
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.D))
                DamagePlayer?.Invoke();

            if(Input.GetKeyDown(KeyCode.H))
                HealPlayer?.Invoke();

            if(Input.GetKeyDown(KeyCode.X))
                GiveExperienceToPlayer?.Invoke();
        }
    }
}
