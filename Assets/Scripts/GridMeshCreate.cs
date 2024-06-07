using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMeshCreate : MonoBehaviour
{
    [Serializable]
    public class MeshRange
    {
        public int widght;
        public int height;
    }
    public MeshRange meshRange;
    public Vector2 startPos;
    public Transform parentTran;
    public GameObject gridPre;

    
    public MyGrid[,] m_grids;
    public MyGrid[,] MeshGridData
    { 
        get { return m_grids; }
    }

    public Action<MyGrid> gridEvent;

    public void CreateMesh()
    {
        if(meshRange.widght == 0 || meshRange.height==0) 
        {
            return;
        }
        ClearMesh();

        m_grids=new MyGrid[meshRange.widght,meshRange.height];
        for(int i = 0;i<meshRange.widght;i++)
        {
            for(int j=0;j<meshRange.height;j++)
            {
                m_grids[i,j]= CreateGrid(i, j);
                Debug.Log("m_grids[i,j]" + m_grids[i, j]);
            }
        }


    }

    private MyGrid CreateGrid(int row, int column)
    {
        GameObject go = GameObject.Instantiate(gridPre, parentTran);
        MyGrid grid = go.GetComponent<MyGrid>();
        grid.gridIndex=new GridIndex(row,column);
        float posX=startPos.x+grid.gridWidth*row;
        float posY = startPos.y + grid.gridHeight * column;
        go.transform.position = new Vector2(posX, posY);
        m_grids[row, column] = grid;
        gridEvent?.Invoke(grid);
        return grid;
    }

    private void ClearMesh()
    {
        if(m_grids ==null||m_grids.Length==0)
        {
            return;
        }
        
        foreach(MyGrid grid in m_grids)
        {
            if(grid.gameObject!=null)
            {
                Destroy(grid.gameObject);
            }
        }
        Array.Clear(m_grids, 0, m_grids.Length);
    }
}
