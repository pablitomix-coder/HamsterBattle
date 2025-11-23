using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed = 2f;
    public float attackRange = 1f;
    public float attackDamage = 20f;
    public float attackRate = 1f;
    private float nextAttackTime;
    public bool isPlayerUnit;
    private bool isFighting = false;

    private Transform target;

    void Update()
    {
        if (target == null)
        {
            isFighting = false;
            FindTarget();
            MoveForward();
        }

        if (!target.gameObject.activeInHierarchy)
        {
            target = null;
            isFighting = false;
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);
        
        if (distance <= attackRange)
        {
            isFighting = true;
            TryAttack();
        }
        else if (!isFighting) // <- Solo moverse si NO está peleando
        {
            MoveForward();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void FindTarget()
    {
        string enemyUnitTag = isPlayerUnit ? "EnemyUnit" : "PlayerUnit";
        string enemyCastleTag = isPlayerUnit ? "EnemyCastle" : "PlayerCastle";

        // 1. Buscar unidades enemigas primero
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyUnitTag);

        Transform closestUnit = null;
        float minDist = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<UnitHealth>() == null) continue; // Solo unidades

            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closestUnit = enemy.transform;
            }
        }

        // Si encontramos una unidad enemiga -> usarla como target
        if (closestUnit != null)
        {
            target = closestUnit;
            return;
        }

        // 2. Si no hay unidades -> buscar su castillo (correctamente)
        GameObject castle = GameObject.FindGameObjectWithTag(enemyCastleTag);
        if (castle != null)
        {
            target = castle.transform;
        }
    }

    void MoveForward()
    {
        float direction = isPlayerUnit ? 1 : -1;
        transform.Translate(Vector2.right * (direction * speed * Time.deltaTime));
    }
    void TryAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackRate;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Attack()
    {
        if (target == null) return;

        if (target.CompareTag("EnemyCastle") || target.CompareTag("PlayerCastle"))
        {
            // Es un castillo
            var castleHealth = target.GetComponent<CastleHealth>();
            if (castleHealth != null)
                castleHealth.TakeDamage(attackDamage);
        }
        else
        {
            // Es una unidad
            var unitHealth = target.GetComponent<UnitHealth>();
            if (unitHealth != null)
                unitHealth.TakeDamage(attackDamage);
        }
    }
}
