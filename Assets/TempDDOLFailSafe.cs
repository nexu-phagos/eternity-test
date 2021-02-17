using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDDOLFailSafe : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
