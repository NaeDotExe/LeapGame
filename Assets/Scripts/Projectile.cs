using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Attributes
    [SerializeField] private int _damage = 1;

    private Rigidbody _rigidBody = null;
    #endregion

    #region Properties
    public int Damage
    {
        get { return _damage; }
    }
    #endregion

    #region Methods
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        if (_rigidBody == null)
        {
            Debug.LogError("No Component Rigidbody found.");
            return;
        }
    }

    private void Start()
    {

    }
    private void Update()
    {

    }

    public void AddForce(Vector3 direction, ForceMode mode)
    {
        _rigidBody.AddForce(direction, mode);
    }
    #endregion
}
