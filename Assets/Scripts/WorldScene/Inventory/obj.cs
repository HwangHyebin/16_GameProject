using UnityEngine;
using System.Collections;

public class obj : MonoBehaviour 
{
    private BoxCollider col;
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    void OnPress(bool pressed)
    {
        Debug.Log("press");
        // 아이템을 누르고 있는 동안은 충돌체를 비활성화한다.
        
        col.enabled = pressed;
    
        // 아이템을 드롭하면,
        if (!pressed)
        {
            // UICamera가 감지한 충돌체를 찾는다.
            Collider collider = UICamera.lastHit.collider;
            // 감지한 충돌체가 없거나, 드롭 영역이 아니면
            if (collider == null || collider.GetComponent<ItemDrag>() == null)
            {
                // 부모인 Grid를 찾아서
                UIGrid grid = NGUITools.FindInParents<UIGrid>(gameObject);
                // 원래 위치로 돌아온다.
                if (grid != null) grid.Reposition();
            }
        }
    }
    
}
