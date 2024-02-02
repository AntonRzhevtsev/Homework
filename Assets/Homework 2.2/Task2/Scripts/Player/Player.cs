using System;
using UnityEngine;

namespace Homework2_2Task_2
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        private int _maxLevel;
        private int _currentLevel;
        private float _currentHp;
        private float _maxHp;
        private float _exp;

        public string VisibleLevel => (_currentLevel + 1).ToString();
        public string VisibleMaxHp => _maxHp.ToString();
        public string VisibleCurrentHp => _currentHp.ToString();

        public event Action Died;
        public event Action StatsChanged;
        public event Action LevelUped;

        public void Initialize()
        {
            _currentLevel = 0;

            _maxHp = _playerConfig.HpLevels[_currentLevel];
            _exp = _playerConfig.ExpToLevelUp[_currentLevel];
            _maxLevel = _playerConfig.ExpToLevelUp.Length - 1;

            _currentHp = _maxHp;
        }

        public void GetExp()
        {
            if(_currentLevel != _maxLevel)
                _exp += _playerConfig.XpGain;

            Mathf.Clamp(_exp, 0, _playerConfig.ExpToLevelUp[_maxLevel]);
            Debug.Log(_exp);

            while(_currentLevel != _maxLevel && _exp >= _playerConfig.ExpToLevelUp[_currentLevel + 1])
                LevelUp();
        }

        public void GetDamage()
        {
            _currentHp -= _playerConfig.DamageGain;
            Mathf.Clamp(_currentHp, 0f, _maxHp);
            StatsChanged?.Invoke();

            if(_currentHp == 0f)
                Die();
        }

        public void GetHeal()
        {
            if(_currentHp == _maxHp)
                return;
            
            _currentHp += _playerConfig.HealGain;
            Mathf.Clamp(_currentHp, 0f, _maxHp);
            StatsChanged?.Invoke();
        }

        private void LevelUp()
        {
            _currentLevel += 1;
            _maxHp = _playerConfig.HpLevels[_currentLevel];
            _currentHp += _playerConfig.HpLevels[_currentLevel] - _playerConfig.HpLevels[_currentLevel - 1];

            StatsChanged?.Invoke();
            LevelUped?.Invoke();
        }

        private void Die() => Died?.Invoke();
    }
}
