using UnityEngine;

public class FruitTrader : Trader
{
    [SerializeField] private int _fruitCost;

    protected override void Sell()
    {
        if(_player.Money - _fruitCost < 0)
        {
            SayNotEnoughMoney();
            return;
        }

        _player.TakeFruits(1);
        _player.Pay(_fruitCost);
        _player.PrintInventory();
    }
}
