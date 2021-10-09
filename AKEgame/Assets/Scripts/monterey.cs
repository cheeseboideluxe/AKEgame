using UnityEngine;

public class monterey : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 1;
    public HealthbarBehaviour Healthbar;


    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}