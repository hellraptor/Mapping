using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class BinaryMap : MonoBehaviour
{

    public Transform _cell;
    public Transform mapPanel;
    public Transform camera;
    public List<Cell> cells = new List<Cell>();

    void Start()
    {
    }

    void Update()
    {
    }

    public void AddCell(Cell cell)
    {
        cells.Add(cell);
        Transform cellObject = (Transform)Instantiate(_cell, camera.position - new Vector3(0, 16, 0) + new Vector3(cell.x, 0, cell.y), Quaternion.identity);
        cellObject.SetParent(mapPanel.transform);
    }
}
