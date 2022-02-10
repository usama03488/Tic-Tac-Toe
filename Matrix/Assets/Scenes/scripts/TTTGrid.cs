using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTGrid : Matrix
{
 
    public int NumberofRows;
    public int NumberofColumns;
    NonMonoCell nonmonocell;
    private int mouseclick=0;

    private bool IsChecker=false;
    private bool IsCheckWin = false;
    List<List<NonMonoCell>> cells;
    public delegate void OnCreatedCell(NonMonoCell cell);
    public OnCreatedCell oncreated;
   public CellView cellings;
    private int ischnagestate = 0;
    private bool checkingWin = false;

    // Start is called before the first frame update
  public  TTTGrid(int r,int c) : base(r,c)
    {
        NumberofRows=r;
        NumberofColumns=c;
        cells = new List<List<NonMonoCell>>();
        cellings = new CellView();
    }
    public TTTGrid()
    {

    }
    void Start()
    {
       
    }
   public void Oninitialize()
    {
     
        for (int i = 0; i <NumberofRows ; i++)
        {
            cells.Add(new List<NonMonoCell>());

            for (int j = 0; j < NumberofColumns; j++)
            {
                NonMonoCell tempcell = new NonMonoCell(i, j);
                cells[i].Add(tempcell);
                oncreated?.Invoke(cells[i][j]);
                tempcell.updatestatus += UpdateStatus;
                SetElement(i, j, (int)NonMonoCell.Status.none);
             
            }
        }
    
      

    }
    void CheckWin()
    {
        bool roww = false;
        bool colu = false;
        bool Diagnols = true;
        for (int i = 0; i < NumberofRows; i++)
        {          
                roww = IsRowSame(i);
            if (roww == true)
            {
                checkingWin = true;
                roww = true;
                break;
            }
            else
            {
                checkingWin = false;
                roww = false;
            }
              

        }
        if (checkingWin==false)
        {
            for (int i = 0; i < NumberofColumns; i++)
            {
                colu = IsColunmSame(i);

                if (colu == true)
                {
                    checkingWin = true;
                    colu = true;
                    break;
                }
                else
                {
                    checkingWin = false;
                    colu = false;

                }
                    
            }
        }

        if (checkingWin == false && colu== false && roww==false)
        {
            Diagnols = IsDiagnolSame();
            if (Diagnols == true)
            {
                checkingWin = true;
            }
        }


    }
    void CheckDraw()
    {
        CheckMatrix();
        if (IsChecker == false)
        {
            Debug.Log("cell are not filled completely");
        }
        else
        {
            if(checkingWin == false)
            {
                Debug.Log("Match drawn");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckMatrix()
    {
        for (int i = 0; i < NumberofRows; i++)
        {
            for (int j = 0; j < NumberofColumns; j++)
            {
                if (GetElement(i,j)==0)
                {
                    IsChecker = false;
                    break;
                }
                else
                {
                    IsChecker = true;
                }
            }
        }
    }
    void SetState()
    {
        if (mouseclick % 2 == 0)
        {
            ischnagestate = 0;
        }
        else
        {
            ischnagestate = 1;
        }
    }
    public void UpdateStatus(int row, int col)
    {
        SetState();
        if (cells[row][col].Getstatus() == NonMonoCell.Status.none)
        {
            if (checkingWin == false)
            {
                CheckDraw();
                if (ischnagestate == 0)
                {
                    cells[row][col].SetStatus(NonMonoCell.Status.Circle);
                    SetElement(row, col, (int)NonMonoCell.Status.Circle);
                    cells[row][col].SetUnityCellStatus(NonMonoCell.Status.Circle);
                    mouseclick++;
                    CheckWin();
                    
                }
                else if (ischnagestate == 1)
                {
                    cells[row][col].SetStatus(NonMonoCell.Status.Cross);
                    SetElement(row, col, (int)NonMonoCell.Status.Cross);
                    cells[row][col].SetUnityCellStatus(NonMonoCell.Status.Cross);

                    mouseclick++;
                    CheckWin();
                
                }
            }
            else
            {
                Debug.Log("You win");
            }

            //cells[row][col].SetStatus(NonMonoCell.Status.Circle);
            //SetElement(row,col,(int)NonMonoCell.Status.Circle );
            //cells[row][col].SetUnityCellStatus(NonMonoCell.Status.Circle);
            //Debug.Log("Current status changes" + cells[row][col].Getstatus());
        }
    }
    
}
