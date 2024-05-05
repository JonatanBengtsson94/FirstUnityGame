using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform firePoint;

    public void Attack(float angle)
    {
        GetProjectiles().transform.position = firePoint.position;
        GetProjectiles().GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.parent.localScale.x), angle);
    }
    
    private GameObject GetProjectiles()
    {
       foreach (var projectile in projectiles)
       {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
       } 
       return null;
    }
}
