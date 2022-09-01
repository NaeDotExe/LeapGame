using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Attributes
    [SerializeField] private EnemyData _data = null;

    private int _currentHp = 5;
    #endregion

    #region Properties
    public int CurrentHp
    {
        get { return _currentHp; }
    }
    #endregion

    #region Methods
    private void Start()
    {
        _currentHp = _data.HP;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile == null)
            {
                return;
            }

            TakeDamage(projectile.Damage);
        }
    }
    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
    }
    #endregion
}
