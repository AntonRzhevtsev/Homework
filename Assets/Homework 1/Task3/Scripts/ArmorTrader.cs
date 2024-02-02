using UnityEngine;

public class ArmorTrader : Trader
{
    [SerializeField] private int _armorCost;
    protected override void Sell()
    {
        if(_player.Money - _armorCost < 0)
        {
            SayNotEnoughMoney();
            return;
        }

        _player.TakeArmor(1);
        _player.Pay(_armorCost);
        _player.PrintInventory();
    }
}
