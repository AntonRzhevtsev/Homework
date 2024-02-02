using UnityEngine;

namespace Homework2_2Task_2
{
    public class Mediator : MonoBehaviour
    {
        [SerializeField] private HudController _hud;
        [SerializeField] private RestartMenuController _restartMenu;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Player _player;
        [SerializeField] private GameManager _gameManager;

        public void Initialize()
        {
            _inputManager.DamagePlayer += DamagePlayer;
            _inputManager.HealPlayer += HealPlayer;
            _inputManager.GiveExperienceToPlayer += GiveExperienceToPlayer;

            _player.StatsChanged += UpdateVisibleStats; 
            _player.Died += EndGame;
            _player.LevelUped += ShowLevelUpLabel;

            _restartMenu.RestartButtonCliked += RestartGame;

            StartGame();
        }

        private void DamagePlayer() => _player.GetDamage();

        private void HealPlayer() => _player.GetHeal();

        private void GiveExperienceToPlayer() => _player.GetExp();

        private void StartGame()
        {
            _gameManager.StartGame();
            _hud.Show();
            _restartMenu.Hide();
            UpdateVisibleStats();
        }

        private void EndGame()
        {
            _gameManager.EndGame();
            _hud.Hide();
            _restartMenu.Show();
        }

        private void RestartGame() => _gameManager.RestartGame();

        private void UpdateVisibleStats() =>
            _hud.PrintStats(_player.VisibleLevel, _player.VisibleCurrentHp, _player.VisibleMaxHp);

        private void ShowLevelUpLabel() => _hud.ShowLevelUpLabel();

        void OnDestroy()
        {
            _inputManager.DamagePlayer -= DamagePlayer;
            _inputManager.HealPlayer -= HealPlayer;
            _inputManager.GiveExperienceToPlayer -= GiveExperienceToPlayer;
            
            _player.StatsChanged -= UpdateVisibleStats; 
            _player.Died -= EndGame;

            _restartMenu.RestartButtonCliked -= RestartGame;
        }
    }
}
