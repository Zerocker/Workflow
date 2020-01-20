public class Matrix
{
    public double[][] base;

    public Matrix(double[][] numbers)
    {
        base = numbers;
    }

    public String toString()
    {
        String out = "";
        for (int row = 0; row < base.length; row++)
        {
            for (int col = 0; col < base[row].length; col++)
            {
                out += String.format("%-10.2f", base[row][col]);
            }
            out += "\n";
        }        
        return out;    
    }
}