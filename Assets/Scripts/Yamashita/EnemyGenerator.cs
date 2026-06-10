using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyBase enemyPrefab;
    [SerializeField] private float generationInterval;
    [SerializeField] private int burstCount;

    [SerializeField] private float distance;

    private GameObject targetObject;

    private float generationWaitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generationWaitTime = generationInterval;
        targetObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        generationWaitTime -= Time.deltaTime;
        if (generationWaitTime < 0.0f)
        {
            for (int i = 0; i < burstCount; i++)
            {
                EnemyBase newEnemy = Instantiate(enemyPrefab);
                Vector3 summonPosition = targetObject.transform.position;
                float angle = UnityEngine.Random.Range(0.0f, 2.0f * Mathf.PI);
                summonPosition += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
                newEnemy.OnSummon(summonPosition);
            }
            generationWaitTime = generationInterval;
        }
    }
}
