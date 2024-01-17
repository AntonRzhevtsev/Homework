using UnityEngine;

public class FruitTrader : Trader
{
    [SerializeField] int fruitCost;
    protected override void Sell()
    {
        if(_player.money - fruitCost < 0)
        {
            SayNotEnoughMoney();
            return;
        }

        _player.fruits += 1;
        _player.money -= fruitCost;

        CallSellEvent();
    }
}
