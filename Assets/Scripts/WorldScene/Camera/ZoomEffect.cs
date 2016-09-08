using UnityEngine;
using System.Collections;

public class ZoomEffect : MonoBehaviour 
{
    private  Camera      target;
    public  UISprite    img;
    private bool        check = false;
    private int         min = 15;
    private int         max = 60;
    private int         smooth = 5;

	private void Update () 
    {
        if (target == null && Application.loadedLevelName == "stage")
        {
            target = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        else if (target != null)
        {
            if (check == true)
                target.fieldOfView = Mathf.Lerp(target.fieldOfView, min, Time.deltaTime * smooth);
            else
                target.fieldOfView = Mathf.Lerp(target.fieldOfView, max, Time.deltaTime * smooth);
        }
	}
    public void Toggle_Button()
    {
        //인벤토리에 있는 아이템을 전부 저장.
        //Application.LoadLevel(2);// test
        if (check == true)
        {
            check = false;
            img.spriteName = "retun";
        }
        else
        {
            check = true;
            img.spriteName = "full_screen";
        }
    }
}
