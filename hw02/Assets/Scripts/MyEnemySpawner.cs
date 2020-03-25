using UnityEngine;

public class MyEnemySpawner : MonoBehaviour
{
    [SerializeField] private float _period;
    public GameObject Enemy;
    private float _timeUntilNextSpawn;

    void Start()
    {
        _timeUntilNextSpawn = Random.Range(0, _period);    
    }

    void Update()
    {
        _timeUntilNextSpawn -= Time.deltaTime;
        if (_timeUntilNextSpawn <= 0.0f)
        {
            _timeUntilNextSpawn = _period;
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
}
