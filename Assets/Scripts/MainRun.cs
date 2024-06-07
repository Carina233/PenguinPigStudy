using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainRun : MonoBehaviour
{
    public GridMeshCreate gridMeshCreate;

    [Range(0f, 1f)]
    public float probaility;

    private void Update()
    {
        //Debug.Log("11");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("22");
            Run();
        }
    }
    private void Run()
    {
        gridMeshCreate.gridEvent = GridEvent;
        gridMeshCreate.CreateMesh();
        

    }

    private void GridEvent(MyGrid grid)
    {
        float f= Random.Range(0,1.0f);
        Debug.Log(f.ToString());
        grid.color = f<=probaility ? Color.red : Color.white;
        grid.isHinder = f<=probaility;
        grid.OnClick = () =>
        {
            Debug.Log("grid.OnClick");
            if(grid.isHinder)
            {
                return;
            }

            foreach (MyGrid grid in gridMeshCreate.MeshGridData)
            {
                if(grid.isSelect==true)
                {
                    grid.isSelect = !grid.isSelect;
                }
            }
            grid.isSelect = !grid.isSelect;

            

        };

    }

    public void FromGridToIndex()
    {
        MyGrid[,] myGrids = gridMeshCreate.MeshGridData;
        MyGrid endGrid = new MyGrid();
        MyGrid startGrid = new MyGrid();
        foreach (MyGrid grid in myGrids)
        {
            if (grid.endGrid == true)
            {
                endGrid = grid;
            }
            else if (grid.isSelect == true)
            {
                startGrid = grid;
            }
        }
    }

    /// <summary>
    /// value=0 normal
    /// value=-1 hinder
    /// </summary>
    /// <param name="MapArr"></param>
    public void AStarCalculate(GridIndex start, int[,] MapArr, GridIndex end)
    {
       

    }
}
