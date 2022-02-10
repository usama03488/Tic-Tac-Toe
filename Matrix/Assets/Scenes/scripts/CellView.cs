using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    public GameObject[] Statuses;
    NonMonoCell noncell;
    public NonMonoCell cells;
    private int row;
    private int col;
    private float Horizontal;
    private float Vertical;

    // Start is called before the first frame update
    public CellView(int r,int c)
    {   row = r;
        col = c;

    }
    public CellView()
    {
   

    }
    public void SetRowandCol(int r, int c)
    {
        row = r;
        col = c;

    }
    public void SetPosition(float horizontal,float vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }
    public void SetCell(NonMonoCell cell)
    {
        cells=cell;
    }
    private void OnMouseDown()
    {

        cells.statuses += setStatus;
        cells.Interaction();
   

    }
    void Start()
    {
        //noncell = new NonMonoCell(row, col);
        //noncell.newstatus += setStatus;
        //setStatus(NonMonoCell.Status.none);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Interaction();
        
    //        Debug.Log("Mouse button pressed");
    //    }
    //}
  public  void setStatus(NonMonoCell.Status status )
    {
 
        for (int i = 0;i < Statuses.Length; i++)
        {
            if (i == (int)status)
            {
                Statuses[i].SetActive(true);
            }
            else
            {
                Statuses[i].SetActive(false);
            }
        }
    }
   
}
