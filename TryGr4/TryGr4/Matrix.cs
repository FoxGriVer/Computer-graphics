using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGr4
{
    public class Matrix
    {
        public List<GeoPoint> matrix = new List<GeoPoint>();

        public void AddNode(GeoPoint inputPoint)
        {
            matrix.Add(new GeoPoint(inputPoint.coord[0], inputPoint.coord[1], inputPoint.coord[2], inputPoint.coord[3]));
        }

        public Matrix MakeCopy()
        {
            Matrix result = new Matrix();
            for (int i = 0; i < matrix.Count; i++)
                result.AddNode(new GeoPoint(matrix[i].coord[0], matrix[i].coord[1], matrix[i].coord[2], matrix[i].coord[3]));
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result = m1.MakeCopy();
            double tmp = 0;
            for (int k = 0; k < m1.matrix.Count; k++)
            {
                for (int i = 0; i < m2.matrix.Count; i++)
                {
                    for (int j = 0; j < m2.matrix.Count; j++)
                    {
                        tmp += m1.matrix[k].coord[j] * m2.matrix[j].coord[i];
                    }
                    result.matrix[k].coord[i] = tmp;
                    tmp = 0;
                }
            }
            return result;
        }    

    }
}
