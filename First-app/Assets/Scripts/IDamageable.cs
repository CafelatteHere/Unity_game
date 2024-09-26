using UnityEngine;

public interface IDamageable 
{
    // no "public / protected/ private" words can be used in interface funtions. They are public by default.
    void TakeDamage(Vector2 direction, float damageAmount);    
}
