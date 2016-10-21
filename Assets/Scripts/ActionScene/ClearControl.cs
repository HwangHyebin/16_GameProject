using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClearControl : MonoBehaviour 
{
    public  Button  button;
    public  Text    _text;
    public  Sprite[] sprites;

    private int       select_nums;
    private Inventory   srt_inven;
    private GameObject  robbyUI;
    private static int open_count;


	private void Start () 
    {
        robbyUI = GameObject.Find("RobbyUI");
        srt_inven = GameObject.Find("RobbyUI").GetComponentInChildren<Inventory>();

        select_nums = Random.Range(1, ItemManager.Instance.GetItemsCount()+1);
        _text.gameObject.SetActive(false);
        open_count = 0;
        //StartCoroutine("DelayOpen");
	}
	
	private void Update () 
    {
	}
    public void ButtonPress()
    {
        Debug.Log(select_nums);
        Debug.Log(sprites[select_nums]);
        ++open_count;
        _text.gameObject.SetActive(true);
        button.image.sprite = sprites[select_nums-1];
        _text.text = ItemManager.Instance.GetItem(select_nums).INFO;
        srt_inven.AddItem(select_nums);
        
        Debug.Log("clear select = "+select_nums);
        StartCoroutine("NextScene");
    }
    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(10.0f);
        //Open();
        StartCoroutine("NextScene");
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(7.0f);
        robbyUI.transform.FindChild("Anchor").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Top_right").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Bottom_Left").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Center").gameObject.SetActive(true);
        Application.LoadLevel(1);
    }
}
