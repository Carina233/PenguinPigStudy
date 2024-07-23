using System;
using UnityEngine;

[System.Serializable]
public struct GridIndex
{
    public int rowIndex;
    public int columnIndex;
    public GridIndex(int rowIndex, int columnIndex)
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
    }

    public override string ToString()
    {
        return $"({rowIndex}, {columnIndex})";
    }
}
public class MyGrid : MonoBehaviour
{
    public GridIndex gridIndex;
    public float gridWidth;
    public float gridHeight;
    public bool isHinder;
    public bool endGrid;
    [SerializeField]
    private bool select;
    public bool isSelect { 
        get { return select; }
        set { 
            select= value;
            if (select)
            {
                color = Color.blue;
            }
            else
            {
                color = Color.white;
            }
                
            }
    }

    public Color color;
    public Action OnClick;
    

    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = color;
        
    }
    private void OnMouseDown()
    {
        //Debug.Log("OnMouseDown");
        //Debug.Log(OnClick.ToString());
        //OnClick?.Invoke();
    }
}
