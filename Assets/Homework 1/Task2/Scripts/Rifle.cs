using UnityEngine;

public class Rifle : IGun, IReloadable
{
    private Shooter _shooter;
    private int _currentRounds;
    private int _maxRounds;
    private GameObject _bullet;
    private bool _ableToShoot;

    public Rifle(Shooter shooter, int maxRounds, GameObject bullet)
    {
        _shooter = shooter;
        _maxRounds = maxRounds;
        _bullet = bullet;
        _currentRounds = _maxRounds;
        _ableToShoot = true;
        PrintRounds();
    }

    public void Reload()
    {
        _currentRounds = _maxRounds;
        PrintRounds();
        _ableToShoot = true;
    }

    public void Shoot()
    {
        if(_ableToShoot)
        {
            GameObject.Instantiate(_bullet, _shooter.Transform.position, _shooter.Transform.rotation);
            _currentRounds--;
            PrintRounds();
            
            if(_currentRounds == 0)
                _ableToShoot = false;
        }
        else
            Debug.Log("Click");
        
    }

    private void PrintRounds() => Debug.Log($"Magazine: {_currentRounds} rounds");
}
