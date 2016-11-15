using UnityEngine;
using System.Collections;

public class LoadSprite : MonoBehaviour 
{
    public  UISprite    load;
    private int         startTime = 0;

    private void Update()
    {
        load.transform.Rotate(Vector3.forward * Time.deltaTime * 100.0f * -1.0f);
        if (Time.time > startTime + 3.0f)
        {
            if (Data.characters.Count != 0 && Data.characters.Count != 0) //로딩 끝
            {
                Application.LoadLevel(2);
            }
        }
    }
}
