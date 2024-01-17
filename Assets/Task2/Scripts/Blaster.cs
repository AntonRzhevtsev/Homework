using UnityEngine;

public class Blaster : IGun
{
    IShooter _shooter;
    GameObject _bullet;

    public Blaster(IShooter shooter, GameObject bullet)
    {
        _shooter = shooter;
        _bullet = bullet;
    }

    public void Reload() {}

    public void Shoot()
    {
        GameObject.Instantiate(_bullet, _shooter.Transform.position, _shooter.Transform.rotation);
    }
}
