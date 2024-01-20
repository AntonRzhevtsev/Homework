using System;
using UnityEngine;

public abstract class Trader : MonoBehaviour
{
    public event Action SoldItem;
    protected Player _player;
    private bool isSelling = false;

    protected abstract void Sell();

    protected void SayNotEnoughMoney() => Debug.Log($"{_player.name} doesn't have enough money");

    private void Update()
    {
        if(isSelling && Input.GetKeyDown(KeyCode.B))
            Sell();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out _player))
            isSelling = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _player = null;
        isSelling = false;
    }
}
