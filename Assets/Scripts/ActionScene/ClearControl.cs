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
        ++open_count;
        _text.gameObject.SetActive(true);
        button.image.sprite = sprites[select_nums-1];
        _text.text = ItemManager.Instance.GetItem(select_nums).INFO;
        if (ItemManager.Instance.GetItem(select_nums).NAME == "gold")
        {
            int rand = Random.Range((int)ItemManager.Instance.GetItem(select_nums).MIN, (int)ItemManager.Instance.GetItem(select_nums).MAX);
            Data.characters[3].Gold += rand;
        }
        else
        {
            srt_inven.AddItem(select_nums);
        }
        StartCoroutine("NextScene");
    }
    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(5.0f);
        //Open();
        StartCoroutine("NextScene");
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3.0f);
        robbyUI.transform.FindChild("Anchor").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Top_right").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Bottom_Left").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Center").gameObject.SetActive(true);
        robbyUI.GetComponentInChildren<AudioSource>().Play();
        Application.LoadLevel(2);
    }
}
