using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalparent;
    public Inventory myBag;
    private int currentItemID;//��ǰ��Ʒ��ID

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalparent = transform.parent;
        currentItemID = originalparent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//�����굱ǰλ���µ���һ���������������
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemList����Ʒ�洢λ�øı�
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalparent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalparent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;//�����赲��������Ȼ�޷��ٴ�ѡ���ƶ�����Ʒ
                return;
            }


            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)"/*&&*/)
            {
                //����ֱ�ӹ��ڼ�⵽��Slot����
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //item List����Ʒ�洢λ�øı�
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];
                //����Լ������Լ�λ�õ�����
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                {
                    myBag.itemList[currentItemID] = null;
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }

        //�����κ�λ�ö���λ��Ʒ
        transform.SetParent(originalparent);
        transform.position = originalparent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
