using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

using System.Runtime.Versioning;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }
    // Start is called before the first frame update
    [SerializeField]public Transform DamageDisplay;
}
