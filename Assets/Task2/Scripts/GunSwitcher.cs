using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Shooter _shooter;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            _shooter.EquipGun(new Blaster(_shooter, _bullet));
            Debug.Log("You equiped blaster");
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {
            _shooter.EquipGun(new Rifle(_shooter, 30, _bullet));
            Debug.Log("You equiped rifle");
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {
            _shooter.EquipGun(new Shotgun(_shooter, 8, _bullet, 30f));
            Debug.Log("You equiped shotgun");
        }
    }
}
