using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshButton : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    public void Refresh()
    {
        _target.SetActive(false);
        _target.SetActive(true);
    }
}
