using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{

    public void DestroyProjectile(Projectile projectile)
    {
        if (projectile.CompareTag("Projectile"))
        {
            projectile.SpawnEffect();
            Destroy(projectile);
        }
    }
}
