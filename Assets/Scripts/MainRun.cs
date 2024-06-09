using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainRun : MonoBehaviour
{
    public GridMeshCreate gridMeshCreate;
    public Dictionary<GridIndex, GridInfo> keyValuePairs;

    [Range(0f, 1f)]
    public float probaility;
    private void Start()
    {
        //FakeDataTest();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FakeDataTest();
        
    }

        //Debug.Log("11");
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("22");
        //    Run();
        //}
    }
    private void Run()
    {
        gridMeshCreate.gridEvent += GridEvent;
        gridMeshCreate.CreateMesh();


    }

    private void GridEvent(MyGrid grid)
    {

        grid.color = keyValuePairs[grid.gridIndex].isHinder? Color.red : Color.white;
        grid.isHinder = keyValuePairs[grid.gridIndex].isHinder;


        //float f= UnityEngine.Random.Range(0,1.0f);
        //Debug.Log(f.ToString());
        //grid.color = f<=probaility ? Color.red : Color.white;
        //grid.isHinder = f<=probaility;
        //grid.OnClick = () =>
        //{
        //    Debug.Log("grid.OnClick");
        //    if(grid.isHinder)
        //    {
        //        return;
        //    }

        //    foreach (MyGrid grid in gridMeshCreate.MeshGridData)
        //    {
        //        if(grid.isSelect==true)
        //        {
        //            grid.isSelect = !grid.isSelect;
        //        }
        //    }
        //    grid.isSelect = !grid.isSelect;



        //};

    }
    private void OnClickGrid()
    {

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

    public class GridInfo
    {
        public GridIndex index;
        public GridIndex parent;
        public bool isHinder;
        public float g;//¿€º∆µƒæ‡¿Îstart
        public float h;//æ‡¿Îend
        public float f;//æ‡¿Îall
    }
    public void FakeDataTest()
    {
        int rows = 20;
        int columns = 20;
        float probaility = 0.2f;
        GridIndex start = new GridIndex(0, 0);
        GridIndex end = new GridIndex(rows - 1, columns - 1);

        List<GridIndex> hinders = new List<GridIndex>();
        

        for (int i=0;i<rows;i++)
        {
            for(int j=0;j<columns;j++)
            {
                if ((i == 0 && j == 0) || (i == rows - 1 && j == columns - 1))
                {
                    continue;
                }
                float f = UnityEngine.Random.Range(0, 1.0f);
                if (f <= probaility)
                {
                    hinders.Add(new GridIndex(i, j));
                }
                
            }
        }
    //    List<GridIndex> hinders = new List<GridIndex>() {
    //        new GridIndex(1,2),
    //        new GridIndex(2,2),
    //        new GridIndex(3, 1),
    //        new GridIndex(3, 2),

    //};

        keyValuePairs = new Dictionary<GridIndex, GridInfo>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GridInfo info = new GridInfo();
                GridIndex gridIndex = new GridIndex(i, j);
                info.isHinder = false;
                info.g = 0;
                info.h = 0;
                info.f = 0;
                keyValuePairs.Add(gridIndex, info);
            }
        }

        foreach (GridIndex index in hinders)
        {
            keyValuePairs[index].isHinder = true;
        }
        gridMeshCreate.gridEvent += GridEvent;
        gridMeshCreate.CreateMeshTest(rows, columns);

        gridMeshCreate.MeshGridData[start.rowIndex,start.columnIndex].color = Color.grey;

        

        FindPath(start, end, keyValuePairs);
    }

    public void OutputFinalPath(Dictionary<GridIndex, GridInfo> close,GridIndex end)
    {
        GridIndex m_end = end;
        
        while (m_end.rowIndex!=0||m_end.columnIndex!=0)
        {
            gridMeshCreate.MeshGridData[m_end.rowIndex, m_end.columnIndex].color = Color.green;
            m_end = close[m_end].parent;
            Debug.Log("m_end:"+ m_end);
        }
        gridMeshCreate.MeshGridData[end.rowIndex, end.columnIndex].color = Color.cyan;
    }


    public void FindPath(GridIndex start, GridIndex end, Dictionary<GridIndex, GridInfo> map)
    {
        Dictionary<GridIndex, GridInfo> open = new Dictionary<GridIndex, GridInfo>();
        Dictionary<GridIndex, GridInfo> close = new Dictionary<GridIndex, GridInfo>();
        GridIndex current = start;
        List<GridIndex> neighbor = new List<GridIndex>() {
            new GridIndex(-1,-1),
            new GridIndex(-1, 0),
            new GridIndex(-1, 1),
            new GridIndex(0, -1),
            new GridIndex(0, 1),
            new GridIndex(1, -1),
            new GridIndex(1, 0),
            new GridIndex(1, 1),

        };

        close.Add(start, map[start]);

        while (true)
        {
            int row = current.rowIndex;
            int column = current.columnIndex;

            if ((row == end.rowIndex && column == end.columnIndex) || close.Count == map.Count)
            {
                break;
            }

            foreach (GridIndex index in neighbor)
            {
                GridIndex gridIndex = new GridIndex(row + index.rowIndex, column + index.columnIndex);
                if (map.ContainsKey(gridIndex) && !open.ContainsKey(gridIndex) && !close.ContainsKey(gridIndex))
                {
                    if (map[gridIndex].isHinder)
                    {
                        continue;
                    }
                    map[gridIndex].parent = current;
                    CalculateDistance(map[gridIndex].parent, gridIndex, end, out map[gridIndex].g, out map[gridIndex].h);
                    map[gridIndex].g += map[map[gridIndex].parent].g;
                    map[gridIndex].f = map[gridIndex].g + map[gridIndex].h;
                    open.Add(gridIndex, map[gridIndex]);
                }
                else if(map.ContainsKey(gridIndex) && open.ContainsKey(gridIndex) && !close.ContainsKey(gridIndex))
                {
                    if (map[gridIndex].isHinder)
                    {
                        continue;
                    }
                    
                    CalculateDistance(current, gridIndex, end, out float newg, out map[gridIndex].h);
                    if(newg+ map[map[current].parent].g < map[gridIndex].g+ map[map[gridIndex].parent].g)
                    {
                        map[gridIndex].parent = current;
                        CalculateDistance(map[gridIndex].parent, gridIndex, end, out map[gridIndex].g, out map[gridIndex].h);
                        map[gridIndex].g += map[map[gridIndex].parent].g;
                        map[gridIndex].f = map[gridIndex].g + map[gridIndex].h;
                        open[gridIndex] = map[gridIndex];
                    }
                }
            }

            var minEntry = open.Aggregate((l, r) => l.Value.f < r.Value.f ? l : r);
            Debug.Log(minEntry);
            close.Add(minEntry.Key, minEntry.Value);

            gridMeshCreate.MeshGridData[minEntry.Key.rowIndex, minEntry.Key.columnIndex].color = Color.yellow;
            //grid.color = keyValuePairs[grid.gridIndex].isHinder ? Color.red : Color.white;

            open.Remove(minEntry.Key);
            current = minEntry.Key;
        }
        OutputFinalPath(close,end);

    }

    public void CalculateDistance(GridIndex parent, GridIndex current, GridIndex end, out float g, out float h)
    {
        g = Mathf.Sqrt(Mathf.Pow(current.rowIndex - parent.rowIndex, 2) +
            Mathf.Pow(current.columnIndex - parent.columnIndex, 2));
        h = Mathf.Abs(end.rowIndex - current.rowIndex) + Mathf.Abs(end.columnIndex - current.columnIndex);

    }

    /// <summary>
    /// value=0 normal
    /// value=-1 hinder
    /// </summary>
    /// <param name="MapArr"></param>
    public void AStarCalculate(GridIndex start, int[,] MapArr, GridIndex end)
    {
        GridIndex current = new GridIndex(start.rowIndex, start.columnIndex);




    }
}
