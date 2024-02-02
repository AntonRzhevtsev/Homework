using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money => _money;
    [SerializeField] private int _money;
    [SerializeField] private int _armor;
    [SerializeField] private int _fruits;

    public void Pay(int price) => _money -= price;

    public void TakeFruits(int fruits) => _fruits += fruits;

    public void TakeArmor(int armor) => _armor += armor;

    public void PrintInventory() => Debug.Log($"{name} has {_money} money, {_armor} armor and {_fruits} fruits.");

}
