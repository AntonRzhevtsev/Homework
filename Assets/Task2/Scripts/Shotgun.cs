using UnityEngine;

public class Shotgun : IGun, IReloadable
{
    private Shooter _shooter;
    private GameObject _bullet;
    private int _maxRounds;
    private int _currentRounds;
    private float _bulletSpread;

    public Shotgun(Shooter shooter, int maxRounds, GameObject bullet, float bulletSpread)
    {
        _shooter = shooter;
        _maxRounds = maxRounds;
        _bullet = bullet;
        _bulletSpread = bulletSpread;
        _currentRounds = _maxRounds;
        PrintRounds();
    }

    public void Reload()
    {
        _currentRounds = _maxRounds;
        PrintRounds();
    }

    public void Shoot()
    {
        if(_currentRounds == 0)
        {
            Debug.Log("*Click*");
            return;
        }

        Quaternion defaultRotation = _shooter.Transform.rotation;

        for(int i = -1; i <= 1; i++)
            GameObject.Instantiate(_bullet, _shooter.Transform.position, 
                Quaternion.Euler(defaultRotation.x, defaultRotation.y + i * _bulletSpread, defaultRotation.z));

        _currentRounds--;
        PrintRounds();
    }

    private void PrintRounds() => Debug.Log($"Magazine: {_currentRounds} rounds");
}
