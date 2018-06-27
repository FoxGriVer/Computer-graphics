using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gr3V2
{
    [Serializable]
    public class Array3x3
    {
        public List<OurPoint> secondListOfPoints = new List<OurPoint>();

        public void Initialize()
        {
            if (secondListOfPoints.Count == 0)
            {
                AddRow(new OurPoint(0, 0, 0));
                AddRow(new OurPoint(0, 0, 0));
                AddRow(new OurPoint(0, 0, 0));
            }
        }

        public Array3x3 ToCopy()
        {
            Array3x3 buffer = new Array3x3();
            for(int i = 0; i < secondListOfPoints.Count; i++)
            {
                buffer.AddRow(new OurPoint(secondListOfPoints[i].X, secondListOfPoints[i].Y, secondListOfPoints[i].H));
            }
            return buffer;
        }

        public void InsertValues(Array3x3 inputArray)
        {
            for (int i = 0; i < inputArray.secondListOfPoints.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    secondListOfPoints[i].listOfCoordinates[j] = inputArray.secondListOfPoints[i].listOfCoordinates[j];
                    switch (j)
                    {
                        case 0:
                            {
                                secondListOfPoints[i].X = inputArray.secondListOfPoints[i].listOfCoordinates[j];
                                break;
                            }
                        case 1:
                            {
                                secondListOfPoints[i].Y = inputArray.secondListOfPoints[i].listOfCoordinates[j];
                                break;
                            }
                        case 2:
                            {
                                secondListOfPoints[i].H = inputArray.secondListOfPoints[i].listOfCoordinates[j];
                                break;
                            }
                    }
                }
            }
        }

        public Array3x3()
        {
        
        }

        public void AddRow(OurPoint inputPoint)
        {
            secondListOfPoints.Add(new OurPoint(inputPoint.X, inputPoint.Y, inputPoint.H));
        }

        public void MultiplyArrays(Array3x3 left, Array3x3 right)
        {
            Array3x3 resultArray = new Array3x3();
            resultArray.Initialize();
            float buffer = 0;
            for (int k = 0; k < left.secondListOfPoints.Count; k++)
            {
                if (k >= 3)
                {
                    resultArray.AddRow(new OurPoint(0, 0, 0));
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        buffer += left.secondListOfPoints[k].listOfCoordinates[j] * right.secondListOfPoints[j].listOfCoordinates[i];
                    }
                    resultArray.secondListOfPoints[k].listOfCoordinates[i] = buffer;
                    buffer = 0;
                }
            }
            if (left.secondListOfPoints.Count != 1)
            {
                InsertValues(resultArray);
            }            
        }
    }
}
