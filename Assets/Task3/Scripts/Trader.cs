using System;
using UnityEngine;

public abstract class Trader : MonoBehaviour
{
    public event Action soldItem;
    protected Player _player;
    bool isSelling = false;

    protected abstract void Sell();

    protected void CallSellEvent() => soldItem.Invoke();

    protected void SayNotEnoughMoney() => Debug.Log($"{_player.name} doesn't have enough money");

    void Update()
    {
        if(isSelling && Input.GetKeyDown(KeyCode.B))
            Sell();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out _player))
            isSelling = true;
    }

    void OnTriggerExit(Collider other)
    {
        _player = null;
        isSelling = false;
    }
}
