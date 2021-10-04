using UnityEngine;
using UnityEngine.Events;

public class ShootingFish : MonoBehaviour
{
    public UnityEvent action;

    public void Action()
    {
        action?.Invoke();
    }
}
