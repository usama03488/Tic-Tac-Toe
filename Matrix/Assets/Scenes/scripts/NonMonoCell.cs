using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMonoCell 
{
  
     int row;
    int col;
  public Status status;
    public delegate void UnityCellStatus(Status stTatus);
    public UnityCellStatus statuses;
    public delegate void UpdateStatus(int row, int col);
    public UpdateStatus updatestatus;
    // Start is called before the first frame update
    public NonMonoCell(int r, int c )
    {
        row = r;
        col = c;
        status = Status.none;
    }
    public   NonMonoCell(int r,int c,Status st)
    {
        row = r;
        col = c;
        status = st;
    
    }
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   public void SetStatus(Status sta)
    {
        status= sta;
        
        //newstatus.Invoke(status);

    }
    public enum Status { none,Circle,Cross, loose,win }
   public void SetRowandCol(int r,int c)
    {
        row = r;
        col= c;
    }
    public int GetRow()
    {
        return row;
    }
    public int GetCol() {
    return col;
    }
    public Status Getstatus()
    {
        return status;
    }
    public int GettStatus()
    {
        return (int)status;
    }
 public  void Interaction()
    {
        
        updatestatus?.Invoke(row, col);
   
    }
    public void SetUnityCellStatus(Status stu)
    {
     
        statuses?.Invoke(stu);
    }
}
