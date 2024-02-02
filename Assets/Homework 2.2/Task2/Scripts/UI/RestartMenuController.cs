using System;
using UnityEngine;
using UnityEngine.UI;

namespace Homework2_2Task_2
{
    public class RestartMenuController : InterfaceOverlay
    {
        public event Action RestartButtonCliked;
        [SerializeField] private Button _restartButton;

        public void Initialize()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Show()
        {
            base.Show();
        }

        public void OnRestartButtonClicked()
        {
            RestartButtonCliked?.Invoke();
        }
    }
}
