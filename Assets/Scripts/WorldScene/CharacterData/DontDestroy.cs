using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour 
{
    private static DontDestroy instance;
    public static DontDestroy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DontDestroy();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
