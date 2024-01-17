using System;
using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    public event Action<Ball> ballDestroyed;
    Vector3 mousePosition;
    void Update()
    {
        CheckClick();
    }

    void CheckClick()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(mousePosition, Vector3.down);

            foreach(RaycastHit raycastHit in raycastHits)
                if(raycastHit.transform.TryGetComponent(out Ball ball))
                {
                    Destroy(ball.gameObject);
                    ballDestroyed(ball);
                }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mousePosition, Vector3.down * 10f);
    }
}
