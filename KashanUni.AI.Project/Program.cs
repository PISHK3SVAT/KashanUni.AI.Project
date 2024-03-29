﻿// alef
using KashanUni.AI.Project;

var matrix = new int[10, 10];
for (int i = 0; i < matrix.GetLength(0); i++)
	for (int j = 0; j < matrix.GetLength(1); j++)
		matrix[i,j]=(i==j)?0:int.MaxValue;
//row 1
matrix[0, 1] = 9; matrix[0, 9] = 7;
//row 2
matrix[1, 0] = 9; matrix[1, 3] = 6; matrix[1, 4] = 6; matrix[1, 6] = 15;
//row 3
matrix[2, 3] = 3;
//row 4
matrix[3, 1] = 6; matrix[3, 2] = 3; matrix[3, 6] = 8; matrix[3, 7] = 1;
//row 5
matrix[4, 1] = 6;
//row 6
//row 7
matrix[6, 1] = 15; matrix[6, 3] = 8;
//row 8
matrix[7, 3] = 1;
//row 9
//row 10
matrix[9, 0] = 7;



var verticesCount=matrix.GetLength(0);
var unReachableVertices = new List<int>();

for (int i = 0; i < verticesCount;i++)
{
    var rowInfCount = 0;
    for (int j = 0;j < verticesCount;j++)
    {
        if (matrix[i, j] == int.MaxValue)
            rowInfCount++;
    }
    if (rowInfCount == verticesCount - 1)
        unReachableVertices.Add(i);
}

var choromosomeLenght=verticesCount-unReachableVertices.Count;
List<int> allel = new();
for (int i = 0; i < verticesCount; i++)
{
    if (!unReachableVertices.Contains(i))
        allel.Add(i);
}

double Evaluate(Chromosome<int> a)
{
    var tmp = 0D;
    for (int i = 0; i < a.Values.Length; i++)
    {
        var rowNum = a[i];
        var max = 0;
        for (int j = 0; j < matrix!.GetLength(1); j++)
        {
            var val = matrix[rowNum, j];
            if (val!=0 && val != int.MaxValue)
            {
                if (val>max)
                    max = val;
            }
        }
        tmp += max;
    }
    return tmp;
}
var ga = new GA<int>(4, choromosomeLenght, allel, Evaluate);
var result = ga.Execute(100,0.6D,0.6D,0.5D);
var finalRes = result.OrderBy(x => x.fitness).First();




//void PrintMatrix(int[,] matrix)
//{
//    for (int i = 0; i < matrix.GetLength(0); i++)
//    {
//        for (int j = 0; j < matrix.GetLength(1); j++)
//        {
//            var val = matrix[i, j] == int.MaxValue ? "inf" : matrix[i, j].ToString("D3");
//            Console.Write(val + " ");
//        }
//        Console.WriteLine();
//    }
//}