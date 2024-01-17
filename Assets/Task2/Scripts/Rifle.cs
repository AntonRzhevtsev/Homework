using UnityEngine;

public class Rifle : IGun
{
    IShooter _shooter;
    int currentRounds;
    int _maxRounds;
    GameObject _bullet;

    public Rifle(IShooter shooter, int maxRounds, GameObject bullet)
    {
        _shooter = shooter;
        _maxRounds = maxRounds;
        _bullet = bullet;
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

        GameObject.Instantiate(_bullet, _shooter.Transform.position, _shooter.Transform.rotation);
        currentRounds--;
        PrintRounds();
    }

    void PrintRounds() => Debug.Log($"Magazine: {currentRounds} rounds");
}
