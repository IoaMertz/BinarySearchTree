namespace BinaryTreeNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            tree.Insert(6);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(19);
            tree.Insert(12);
            tree.Insert(16);
            tree.Insert(1);
            tree.DisplayTree();
            var kati = tree.Height();
            Console.WriteLine(tree.Search(12)); 
        }
    }
}