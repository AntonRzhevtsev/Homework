using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int money;
    [SerializeField] public int armor;
    [SerializeField] public int fruits;
    Trader trader;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out trader))
            trader.soldItem += PrintInventory;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out trader))
        {
            trader.soldItem -= PrintInventory;
            trader = null;
        }
    }
    void PrintInventory() => Debug.Log($"{name} has {money} money, {armor} armor and {fruits} fruits.");

}
