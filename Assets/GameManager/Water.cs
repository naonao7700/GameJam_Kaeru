using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image image;
    [SerializeField] private Vector3 waterPos;
    [SerializeField] private Vector3 groundPos;

    public void SetWaterFlag( bool value )
    {
        image.enabled = value;
        if( value )
        {
            rect.anchoredPosition = waterPos;
        }
        else
        {
            rect.anchoredPosition = groundPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
