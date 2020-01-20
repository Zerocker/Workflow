public class Program
{
    public static void main(String args[])
    {
        Container container = new Container(
            new double[][] {{3, 5, 7}, {7, 7, 5}, {3, 2, 1}},
            new double[][] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}
        );

        container.Multiply();
        System.out.print(container.toString());
    }
}