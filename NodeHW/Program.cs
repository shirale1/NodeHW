namespace NodeHW
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(3, new Node<int>(9, new Node<int>(4))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null
            Console.WriteLine(HomeWork.IfEven(lst1));
            

        }
    }
}