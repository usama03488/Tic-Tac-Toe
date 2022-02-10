using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    private Matrix matrix1=new Matrix(3,3);
    private Matrix matrix2 = new Matrix(3,3);
    int[,] shipPosition = new int[3, 3];
    // Start is called before the first frame update
    void Start()
    {
        setArray();
        matrix1.SetElement(2,2,5);
        matrix1.SetElement(0, 2, 10);
        matrix1.SetElement(0, 2, 9);
        matrix2.SetElement(2, 2, 7);
        matrix2.SetElement(0, 2, 15);
        matrix2.SetElement(0, 2, 9);
        matrix1.Multiplication(matrix1,matrix2);
        matrix1.printmatrix();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setArray()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == 0)
                    shipPosition[i, j] = 3 + 3;
                if (i == 1)
                    shipPosition[i, j] = 6 + 5;
                if (i == 2)
                {
                    shipPosition[i, j] = 25;
                }
            }
        }

    }
}
