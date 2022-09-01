using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Projectile _projectilePrefab = null;

    [Space]
    [SerializeField] private List<Projectile> _prefabs = new List<Projectile>();

    private int _projectileType = 0;
    private bool _leftHandUp = false;
    private bool _rightHandUp = false;
    private bool _canCheckHandsRotation = false;
    private GameObject _leftHand = null;
    private GameObject _rightHand = null;
    #endregion

    #region Methods
    private void Start()
    {
        StartCoroutine(InitCoroutine());
    }
    private void Update()
    {
        if (_canCheckHandsRotation)
        {
            if (_leftHand != null)
            {
                if (_leftHand.transform.eulerAngles.x < 300 && _leftHand.transform.eulerAngles.x > 270)
                {
                    if (!_leftHandUp)
                    {
                        ThrowProjectile(_leftHand.transform);
                    }

                    _leftHandUp = true;
                }
                else
                {
                    _leftHandUp = false;
                }
            }

            if (_rightHand != null)
            {

                if (_rightHand.transform.eulerAngles.x < 300 && _rightHand.transform.eulerAngles.x > 270)
                {
                    if (!_rightHandUp)
                    {
                        ThrowProjectile(_rightHand.transform);
                    }

                    _rightHandUp = true;
                }
                else
                {
                    _rightHandUp = false;
                }
            }
        }
    }

    private void ThrowProjectile(Transform tr)
    {
        // change to pool
        //Projectile projectile = Instantiate(_projectilePrefab, tr.position, Quaternion.identity);
        Projectile projectile = Instantiate(_prefabs[_projectileType], tr.position, Quaternion.identity);
        if (projectile == null)
        {
            Debug.LogError("Projectile is null.");
            return;
        }

        projectile.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }

    public void SelectProjectile(int id)
    {
        _projectileType = id;
    }

    private IEnumerator InitCoroutine()
    {
        yield return new WaitForSeconds(5f);

        _leftHand = GameObject.Find("Left Interaction Hand Contact Bones/Contact Palm Bone");
        _rightHand = GameObject.Find("Right Interaction Hand Contact Bones/Contact Palm Bone");

        if (_leftHand == null)
        {
            Debug.LogError("No Left Hand found!");
            //return;
        }

        if (_rightHand == null)
        {
            Debug.LogError("No Right Hand found!");
            //return;
        }

        _canCheckHandsRotation = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (_leftHand == null)
        {
            return;
        }

        Gizmos.DrawLine(_leftHand.transform.position, _leftHand.transform.forward * 10f);

        if (_rightHand == null)
        {
            return;
        }

        Gizmos.DrawLine(_rightHand.transform.position, _rightHand.transform.forward * 10f);
    }
    #endregion
}