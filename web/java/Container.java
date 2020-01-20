public class Container
{
    private Matrix first;
    private Matrix second;
    private Matrix result;

    public Container()
    {
        first = new Matrix(new double[][] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}});
        second = new Matrix(new double[][] {{1, 1, 1}, {2, 2, 2}, {3, 3, 3}});
    }

    public Container(double[][] a, double[][] b)
    {
        first = new Matrix(a);
        second = new Matrix(b);
    }

    public void Multiply()
    {
        result = new Matrix(new double[first.base.length][second.base[0].length]);

        for (int row = 0; row < first.base.length; row++)
        {
            for (int col = 0; col < second.base[row].length; col++)
            {
                result.base[row][col] = MultiplyCells(first.base, second.base, row, col);
            }
        }
    }

    private double MultiplyCells(double[][] a, double[][] b, int row, int col)
    {
        double cell = 0;
        for (int i = 0; i < b.length; i++)
        {
            cell += a[row][i] * b[i][col];
        }
        return cell;
    }

    public String toString()
    {
        return result.toString();
    }
}