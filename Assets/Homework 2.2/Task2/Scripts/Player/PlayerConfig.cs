using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float[] _hpLevels;
    [SerializeField] private float[] _expToLevelUp;
    [SerializeField] private float _expGain;
    [SerializeField] private float _damageGain;
    [SerializeField] private float _healGain;

    public float[] HpLevels => _hpLevels;
    public float[] ExpToLevelUp => _expToLevelUp;
    public float XpGain => _expGain;
    public float DamageGain => _damageGain;
    public float HealGain => _healGain;
}
