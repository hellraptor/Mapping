using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class BinaryMap : MonoBehaviour
{

    public Transform cellView;
    public Transform mapPanel;
    public Transform camera;
    public float mapSize;
    public int cellsCount;
    float[,] cells;
    float cellSize;


    void Start()
    {
        mapPanel = ((Transform)Instantiate(mapPanel, camera.position - new Vector3(0, 16, 0), Quaternion.identity));
        mapPanel.SetParent(transform);
        cells = new float[cellsCount, cellsCount];
        cellSize = mapSize / cellsCount;
    }

    void Update()
    {
        foreach (Transform child in mapPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < cellsCount; i++)
        {
            for (int j = 0; j < cellsCount; j++)
            {
                if (cells[i, j] > 0)
                {
                    ((Transform)Instantiate(cellView, camera.position + new Vector3(-0.5f * mapSize + cellSize * i, -15, -0.5f * mapSize + cellSize * j), Quaternion.identity)).SetParent(mapPanel);

                }
            }

        }
    }

    public void SetCellValue(int x, int z, float value)
    {
        cells[x, z] = value;
    }

    public int[] ConvertPointToCell(Vector3 point)
    {
        int x = (int)Mathf.Ceil(cellsCount * 0.5f) + (int)Mathf.Ceil(point.x / cellSize);
        int z = (int)Mathf.Ceil(cellsCount * 0.5f) + (int)Mathf.Ceil(point.z / cellSize);
        return new int[] { x, z };
    }

    public void updateMap(List<Vector3> pointsCloud)
    {
        foreach (Vector3 point in pointsCloud)
        {
            int[] cell = ConvertPointToCell(point);
            SetCellValue(cell[0], cell[1], 1);
        }
    }
}
