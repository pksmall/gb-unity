using System.Collections;
using UnityEngine;


public class MyEnemySpawner : MonoBehaviour
{
    #region Fields
    public GameObject Enemy;
    [SerializeField] private MyEnemy _alliveEnemy;
    [SerializeField] private MyEnemy[] _myEnemies;
    [SerializeField] private Transform[] _spawners;
    [SerializeField] private float _period;
    [SerializeField] private float _timeUntilNextSpawn;
    #endregion

    #region UnityMethods
    private void Start()
    {
        StartCoroutine(EnemyChecker());
    }
    #endregion

    #region Methods
    private void Spawn()
    {
        if (_alliveEnemy == null)
        {
            int rndEnemy = Random.Range(0, _myEnemies.Length);
            int rndSpawner = Random.Range(0, _spawners.Length);

            var enemy = _myEnemies[rndEnemy];
            var spawnerPosition = _spawners[rndSpawner];

            _alliveEnemy = Instantiate(enemy, spawnerPosition.position, spawnerPosition.rotation);
        }
    }

    private IEnumerator EnemyChecker()
    {
        while (true)
        {
            if (_alliveEnemy == null)
            {
                yield return new WaitForSeconds(3f);
                Spawn();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion
}
