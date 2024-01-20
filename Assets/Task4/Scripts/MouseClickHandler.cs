using System;
using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    public event Action<Ball> BallDestroyed;
    private Vector3 _mousePosition;
    private void Update()
    {
        CheckClick();
    }

    private void CheckClick()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(_mousePosition, Vector3.down);

            foreach(RaycastHit raycastHit in raycastHits)
                if(raycastHit.transform.TryGetComponent(out Ball ball))
                {
                    Destroy(ball.gameObject);
                    BallDestroyed?.Invoke(ball);
                }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mousePosition, Vector3.down * 10f);
    }
}
