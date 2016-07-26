using UnityEngine;
using System.Collections;

//스킬캐릭터와 enemy가 이 클래스 사용.
public class Life : HPBarBase 
{
	public  float           m_Hight         = 2.0f;
    public  GameObject      UI_back;
    public  GameObject      UI_HP_back;

    private Animator        anim;
    private SpriteRenderer  img;
   
	private void Start ()
    {
        base.Start();
        Set_Target();
        img                 = GetComponent<SpriteRenderer>();
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        anim                = target.GetComponent<Animator>();
	}
	private void Update ()
    {
        UI_HP_back.transform.position = UI_back.transform.position = transform.position = target.position + (Vector3.up * m_Hight);
        UI_HP_back.transform.rotation = UI_back.transform.rotation = transform.rotation = Camera.main.transform.rotation;
        //Debug.Log("life m_hp = " + m_HP);
        //Debug.Log("life status.hp = " + m_HP);
        Vector3 hpScale = m_StartScale;
        if (m_HP > 0.0f)
        {
            hpScale.x = m_HP/start_HP;
            transform.localScale = hpScale;
            if (m_HP / start_HP <= 0.7f)
            {
                rgb.r += 1.0f;
                if (rgb.r >= 255.0f && m_HP / start_HP <= 0.4f)
                {
                    rgb.r = 255.0f;
                    rgb.g -= 1.0f;
                }
                img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
            }
        }
        else
        {
            hpScale.x = 0.0f;
            transform.localScale = hpScale;
            target.GetComponent<Enemy>().enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
            anim.SetInteger("animation", 2);
            StartCoroutine("Death");
        }
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.8f);
        transform.parent.gameObject.SetActive(false);
    }
    private void Set_Target()
    {
        if (transform.parent.tag == "Enemy")
        {
            target = transform.parent.FindChild("mon01");
            start_HP = m_HP = GameObject.FindObjectOfType<Enemy>().status.hp;
        }
        else if (transform.parent.tag == "Skill")
        {
            target = transform.parent;
            if (target.transform.name == "Archer(Clone)")
                start_HP = m_HP = GameObject.FindObjectOfType<Archer>().status.hp;
            else if (target.transform.name == "Magician(Clone)")
                start_HP = m_HP = GameObject.FindObjectOfType<Magician>().status.hp;
            else if (target.transform.name == "Pirate(Clone)")
                start_HP = m_HP = GameObject.FindObjectOfType<Pirate>().status.hp;
        }
    }
}
