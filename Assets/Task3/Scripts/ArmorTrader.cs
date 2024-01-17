using UnityEngine;

public class ArmorTrader : Trader
{
    [SerializeField] int armorCost;
    protected override void Sell()
    {
        if(_player.money - armorCost < 0)
        {
            SayNotEnoughMoney();
            return;
        }

        _player.armor += 1;
        _player.money -= armorCost;

        CallSellEvent();
    }
}
