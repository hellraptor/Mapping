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
    int[,] cells;
    float cellSize;


    void Start()
    {
        ((Transform)Instantiate(mapPanel, camera.position - new Vector3(0, 16, 0), Quaternion.identity)).SetParent(transform);
        cells = new int[cellsCount, cellsCount];
        cellSize = mapSize / cellsCount;
    }

    void Update()
    {
    }

    public void AddCell(int x, int z)
    {
        Transform cellObject = (Transform)Instantiate(cellView, camera.position - new Vector3(0, 16, 0) + new Vector3(x*cellSize, 0, z*cellSize), Quaternion.identity);
        cellObject.SetParent(mapPanel.transform);
    }
}
