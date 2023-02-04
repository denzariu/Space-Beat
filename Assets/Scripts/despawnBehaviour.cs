using UnityEngine;

public class despawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool isBasic;
    [SerializeField]
    private bool isHarmful;

    private enum targetType : ushort { basic, harmful };
    private targetType type;

    [SerializeField]
    private float despawnTime;
    [SerializeField]
    private int pointsPerHit;
    [SerializeField]
    private int hitsNeeded;

    [SerializeField]
    [Tooltip("Blade hit particles")]
    private GameObject hitParticles = null;


    private float time;
    private bool wasHit = false;
    private bool shouldDie = false;

    public bool itHurt() { return isHarmful; }

    private targetType GetTargetType(targetType type)
    {
        if (type == targetType.basic)
            return targetType.basic;

        else if (type == targetType.harmful)
            return targetType.harmful;

        return 0;
    }
    private void SetTypeAttributes()
    {
        if (isBasic)
        {
            type = targetType.basic;
            despawnTime = 6;
            hitsNeeded = 1;
            pointsPerHit = 1;

        }
        else if (isHarmful)
        {
            type = targetType.harmful;
            despawnTime = 6;
            hitsNeeded = 1;
            pointsPerHit = -10;
        }
        else
        {
            type = targetType.basic;
            despawnTime = 6;
            hitsNeeded = 1;
            pointsPerHit = 1;
        }
    }

    public int getPointsPerHit() { return pointsPerHit; }

    public void Hit()
    {
        wasHit = true;
        hitsNeeded--;
        Instantiate(hitParticles, this.transform.position, Quaternion.identity);

        if (hitsNeeded == 0)
        {
            // Add points to scoreboard
            gameManager.IncrementScore(getPointsPerHit());
            // Announce that the object can be sliced / "should die"
            shouldDie = true;
        }
    }

    public bool isDead() { return shouldDie; }
    public void Die() 
    { 
        Destroy(this.gameObject); 
    }


    void Start()
    {
        //time = Time.time;
        //SetTypeAttributes();
    }

}
