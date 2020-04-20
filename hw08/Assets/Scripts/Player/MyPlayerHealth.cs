using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyPlayerHealth : MonoBehaviour
{
    #region Fields
    public int _health = 100;
	public MyHealthBar healthBar;
	// public GameObject deathEffect;
	private int _currentHealth;
	#endregion

	#region UnityMethods
	private void Awake()
	{
		healthBar = gameObject.GetComponentInChildren<MyHealthBar>();
		_currentHealth = _health;
		healthBar.SetHealth(_health);
	}
	#endregion

	#region Methods
	public void AddHealth()
	{
		if (_health < _currentHealth)
		{
			_health += 1;
			healthBar.SetHealth(_health);
		}
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		StartCoroutine(DamageAnimation());

		if (_health <= 0)
		{
			Die();
		}
		healthBar.SetHealth(_health);
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
    #endregion
}
