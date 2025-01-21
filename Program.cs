namespace TestDemo
{
    using System;
    using System.Collections.Generic;

    public class GenericTree
    {
        // Root node
        private Node Root;

        // Tree constructor
        public GenericTree(int numberOfNodes)
        {
            // Throw error if number of nodes is set to a negative number
            if (numberOfNodes is <= 0 or > 100)
            {
                throw new ArgumentException("The number of nodes must be greater than 0 and less than or equal to 100.");
            }

            // Initialize the tree
            int currentId = 0; // Root node gets id 0
            Queue<Node> queue = new Queue<Node>();

            // Create root node
            Root = new Node(currentId++);
            queue.Enqueue(Root);

            // Populate the tree
            while (currentId <= numberOfNodes)
            {
                if (queue.Count == 0)
                {
                    throw new Exception("The queue is prematurely empty.");
                }
                // Get the next node from the queue
                Node currentNode = queue.Dequeue();

                // Determine the number of children (0 to 3)
                Random rnd = new Random();
                int numberOfChildren = rnd.Next(4); // 0 to 3 children

                // If the queue is empty before [numberOfNodes] is reached
                //  -> ensure that the remaining Node in the queue gets at least 1 child
                if (queue.Count == 0 && currentId < numberOfNodes) {
                    numberOfChildren = rnd.Next(1, 4); // 1 to 3 children
                }

                // Create new child nodes as long as [numOfNodes] is not exceeded
                for (int i = 0; i < numberOfChildren && currentId <= numberOfNodes; i++)
                {
                    // Create new child node
                    Node childNode = new Node(currentId++);
                    currentNode.Children.Add(childNode); // Add child Node to parent Node
                    queue.Enqueue(childNode); // Add child Node to queue
                }
            }
        }

        // Print the generated tree structure
        public void PrintTree()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine(
                    $"Node {current.Id}: Children [{string.Join(", ", current.Children.ConvertAll(c => c.Id))}]");

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        // Node class
        class Node
        {
            public int Id { get; }
            public List<Node> Children { get; }

            public Node(int id)
            {
                Id = id;
                Children = new List<Node>();
            }
        }

        // Main funciton
        public static void Main(string[] args)
        {
            // Generate a tree with 10 nodes
            int numberOfNodes = 10;
            GenericTree tree = new GenericTree(numberOfNodes);

            // Print the tree to verify
            tree.PrintTree();
        }
    }
}