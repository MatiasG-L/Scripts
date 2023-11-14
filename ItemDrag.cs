using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IDragHandler ,IBeginDragHandler, IEndDragHandler
{
    private ItemScript itemScript;
    private Transform baseParent;
    private RectTransform hotbarRect;
    private int SiblingIndex;
    // Start is called before the first frame update
    void Start()
    {
        itemScript = GetComponent<ItemScript>();
        baseParent = transform.parent;
        hotbarRect = GameManager.instance.hotbarTransform as RectTransform;
        SiblingIndex = transform.GetSiblingIndex();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(GameManager.instance.mainCanvas);
        itemScript.OnCursorExit();
        itemScript.isBeingDraged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        transform.SetParent(baseParent);
        transform.SetSiblingIndex(SiblingIndex);
        itemScript.isBeingDraged = false;

        if(RectTransformUtility.RectangleContainsScreenPoint(hotbarRect, Input.mousePosition))
        {
            Inventory.instance.SwitchItemInventory(itemScript.Item);
        }
    }



    // Update is called once per frame

}
