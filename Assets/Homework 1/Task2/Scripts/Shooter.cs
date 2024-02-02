using UnityEngine;
using UnityEngine.Scripting;

public class Shooter : MonoBehaviour
{
    public Transform Transform => transform;
    private IGun _currentGun;
    
    public void EquipGun(IGun gun) => _currentGun = gun;

    private void DropGun()
    {
        _currentGun = null;
        Debug.Log("You have no gun!");
    }

    private void MakeShot() => _currentGun.Shoot();

    private void ReloadGun(IReloadable currentGun) => currentGun.Reload();
    
    private void Awake() => DropGun();

    private void Update()
    {
        if(_currentGun == null)
            return;

        if(Input.GetKeyDown(KeyCode.Mouse0))
            MakeShot();
        
        if(Input.GetKeyDown(KeyCode.R) && _currentGun is IReloadable)
            ReloadGun((IReloadable) _currentGun);

        if(Input.GetKeyDown(KeyCode.X))
            DropGun();
    }
}
