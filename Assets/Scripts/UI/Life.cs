using UnityEngine;
using System.Collections;

public class Life : HPBarBase 
{
	public  float           m_Hight         = 2.0f;
    public  GameObject      UI_back;
    public  GameObject      UI_HP_back;

    private Animator        anim;
    private SpriteRenderer  img;
    private Player          srt_player;
   
	private void Start ()
    {
        base.Start();
        img                 = GetComponent<SpriteRenderer>();
        target              = transform.parent.FindChild("mon01");
        m_StartScale        = transform.localScale;
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        //anim                = target.GetComponent<Animator>();
        srt_player          = GameObject.FindObjectOfType<Player>();
        start_HP   = m_HP   = target.GetComponent<Enemy>().status.hp;
	}
	private void Update ()
    {
        UI_HP_back.transform.position = UI_back.transform.position = transform.position = target.position + (Vector3.up * m_Hight);
        UI_HP_back.transform.rotation = UI_back.transform.rotation = transform.rotation = Camera.main.transform.rotation;

        Vector3 hpScale = m_StartScale;
        if (m_HP > 0.0f)
        {
            hpScale.x = hpScale.x * ((float)m_HP * 0.01f);
            transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            transform.localScale = hpScale;
            target.GetComponent<Enemy>().enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
            anim.SetInteger("animation", 2);
            StartCoroutine("Death");
        }
        if (hpScale.x <= 0.8f && srt_player.player_anim == Player.PLAYER_ANIMATOR.ATTACK)
        {
            base.StartCoroutine("Change_Color");
        }   
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.8f);
        transform.parent.gameObject.SetActive(false);
    }
    IEnumerator Change_Color()
    {
        float count = (m_HP / 10.0f);
        if (rgb.b == 0.0f)
        {
            rgb.r += 0.2f * count;
            if (rgb.r >= 255.0f)
            {
                rgb.r = 255.0f;
                rgb.g -= 0.2f * count;
            }
        }
        img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
        yield return new WaitForSeconds(m_HP / start_HP);
    }
}
