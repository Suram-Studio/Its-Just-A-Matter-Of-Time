using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuer : MonoBehaviour
{
    private static Continuer instance1;

    void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
