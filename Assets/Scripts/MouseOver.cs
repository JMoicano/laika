using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public Sprite onMouseOver;
    public Sprite onMouseExit;
    private SpriteRenderer spriteRenderer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteRenderer.sprite = onMouseOver;
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.sprite = onMouseExit;
        Debug.Log("Mouse Exit");
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Mouse Enter");
    }
}
