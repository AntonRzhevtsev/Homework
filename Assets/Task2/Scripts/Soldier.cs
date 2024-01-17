using UnityEngine;

public class Soldier : MonoBehaviour, IShooter
{
    IGun currentGun;

    public Transform Transform {get => transform;}
    
    public void EquipGun(IGun gun) => currentGun = gun;

    void DropGun()
    {
        currentGun = null;
        Debug.Log("You have no gun!");
    }

    void MakeShot() => currentGun.Shoot();

    void ReloadGun() => currentGun.Reload();
    
    void Awake() => DropGun();

    void Update()
    {
        if(currentGun == null)
            return;

        if(Input.GetKeyDown(KeyCode.Mouse0))
            MakeShot();
        
        if(Input.GetKeyDown(KeyCode.R))
            ReloadGun();

        if(Input.GetKeyDown(KeyCode.X))
            DropGun();
    }
}
