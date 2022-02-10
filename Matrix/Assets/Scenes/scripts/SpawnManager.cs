using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int rows;
    public int Columns;
    public float HorizontalSpacing;
    public float VerticalSpacing;
    private int counter;
    private int counterLine=0;
    public CellView celling;
    public GameObject cellPrefabs;

    TTTGrid cellGrid;
    // Start is called before the first frame update
    void Start()
    {
        celling = new CellView();
        InitializeCell();
        
    }
    void InitializeCell()
    {
        cellGrid =new TTTGrid(rows,Columns);
        cellGrid.oncreated += CreatedCell;
        cellGrid.Oninitialize();
    }
    void CreatedCell(NonMonoCell cell)
    {
        Transformposition();
       GameObject eachcell = Instantiate(cellPrefabs, new Vector3(HorizontalSpacing, 0, VerticalSpacing), transform.rotation);
              counter++;
      
        eachcell.GetComponent<CellView>().SetCell(cell);
     
         
    }
    void Transformposition()
    {
        if(counter == rows)
        {
            VerticalSpacing += 1.5f;
            counter = 0;
            HorizontalSpacing = 2.5f;
        }
        else 
        {
            HorizontalSpacing += 1.5f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateStatus()
    {

    }

}
