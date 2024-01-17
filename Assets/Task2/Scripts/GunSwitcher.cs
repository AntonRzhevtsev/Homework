using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Soldier soldier;

    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            soldier.EquipGun(new Blaster(soldier, bullet));
            Debug.Log("You equiped blaster");
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {
            soldier.EquipGun(new Rifle(soldier, 30, bullet));
            Debug.Log("You equiped rifle");
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {
            soldier.EquipGun(new Shotgun(soldier, 8, bullet, 30f));
            Debug.Log("You equiped shotgun");
        }
    }
}
