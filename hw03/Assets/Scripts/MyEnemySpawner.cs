using UnityEngine;


public class MyEnemySpawner : MonoBehaviour
{
    #region Fields
    public GameObject Enemy;
    [SerializeField] private float _period;
    [SerializeField] private float _timeUntilNextSpawn;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _timeUntilNextSpawn = Random.Range(0, _period);    
    }

    private void Update()
    {
        _timeUntilNextSpawn -= Time.deltaTime;
        if (_timeUntilNextSpawn <= 0.0f)
        {
            _timeUntilNextSpawn = _period;
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
    #endregion
}
