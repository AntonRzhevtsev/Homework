using UnityEngine;

public class Shotgun : IGun
{
    IShooter _shooter;
    GameObject _bullet;
    int _maxRounds;
    int currentRounds;
    float _bulletSpread;

    public Shotgun(IShooter shooter, int maxRounds, GameObject bullet, float bulletSpread)
    {
        _shooter = shooter;
        _maxRounds = maxRounds;
        _bullet = bullet;
        _bulletSpread = bulletSpread;
        currentRounds = _maxRounds;
        PrintRounds();
    }

    public void Reload()
    {
        currentRounds = _maxRounds;
        PrintRounds();
    }

    public void Shoot()
    {
        if(currentRounds == 0)
        {
            Debug.Log("*Click*");
            return;
        }

        Quaternion defaultRotation = _shooter.Transform.rotation;

        for(int i = -1; i <= 1; i++)
            GameObject.Instantiate(_bullet, _shooter.Transform.position, 
                Quaternion.Euler(defaultRotation.x, defaultRotation.y + i * _bulletSpread, defaultRotation.z));

        currentRounds--;
        PrintRounds();
    }

    void PrintRounds() => Debug.Log($"Magazine: {currentRounds} rounds");
}
