using UnityEngine;

public class NotTradingTrader : Trader
{
    protected override void Sell() =>
        Debug.Log("Trader doesn't want to trade");
}
