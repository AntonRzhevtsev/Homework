using System.Collections;
using TMPro;
using UnityEngine;

namespace Homework2_2Task_2 
{
    public class HudController : InterfaceOverlay
    {
        [SerializeField] private TextMeshProUGUI _playerInfoText;
        [SerializeField] private TextMeshProUGUI _levelUpText;
        [SerializeField] private float _showLevelUpTime;
        private IEnumerator _showLevelUpTimer;

        public void Initialize()
        {
            _levelUpText.gameObject.SetActive(false);
        }
        
        public override void Hide()
        {
            base.Hide();

            if(_showLevelUpTimer != null)
                StopCoroutine(_showLevelUpTimer);
        }

        public override void Show() => base.Show();

        public void PrintStats(string currentLevel, string currentHp, string maxHp)
        {
            _playerInfoText.text = $"Level: {currentLevel}\nHP: {currentHp} / {maxHp}";
        }

        public void ShowLevelUpLabel()
        {
            if(_showLevelUpTimer != null)
                StopCoroutine(_showLevelUpTimer);

            _showLevelUpTimer = ShowLevelUpTimer();
            StartCoroutine(_showLevelUpTimer);
        }

        private IEnumerator ShowLevelUpTimer()
        {
            _levelUpText.gameObject.SetActive(true);

            yield return new WaitForSeconds(_showLevelUpTime);

            _levelUpText.gameObject.SetActive(false);
        }
    }
}