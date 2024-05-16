using System.Collections;
using System.Collections.Generic;
using Mary.Domain;
using UnityEngine;

public class tester : MonoBehaviour
{
    void Start()
    {
        foreach (var i in new ProductService().GetFeaturedProducts(true))
            Debug.Log(i);
    }
}
