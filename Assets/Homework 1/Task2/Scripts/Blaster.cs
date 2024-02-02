using UnityEngine;

public class Blaster : IGun
{
    private Shooter _shooter;
    private GameObject _bullet;

    public Blaster(Shooter shooter, GameObject bullet)
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
