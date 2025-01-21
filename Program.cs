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
            // Throw error if number of nodes is set to a negative number or larger than 100
            if (numberOfNodes is <= 0 or > Constants.MaxNodes)
            {
                throw new ArgumentException(
                    "The number of nodes must be greater than 0 and less than or equal to 100.");
            }

            // Initialize the tree
            int currentId = 0; // Root node gets id 0
            Queue<Node> queue = new Queue<Node>(); // Initialize Node queue

            // Create root node
            Root = new Node(currentId++, 0);
            queue.Enqueue(Root); // Add root to queue

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

                // If the queue only has 1 Node left, and [numberOfNodes] has not been reached yet
                //  -> ensure that the remaining Node in the queue gets at least 1 child
                if (queue.Count == 0 && currentId < numberOfNodes)
                {
                    numberOfChildren = rnd.Next(1, 4); // 1 to 3 children
                }

                // Create new child nodes as long as [numOfNodes] is not exceeded
                for (int i = 0; i < numberOfChildren && currentId <= numberOfNodes; i++)
                {
                    // Create new child node
                    Node childNode = new Node(currentId++, currentNode.Level + 1);
                    currentNode.Children.Add(childNode); // Add child Node to parent Node
                    queue.Enqueue(childNode); // Add child Node to queue
                }
            }
        }

        // Print the generated tree structure
        public void PrintTree()
        {
            // Initialize printing queue
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root); // Add root
            int currentLevel = 0; // Node level tracker

            // Print Root level
            Console.WriteLine($"Level {currentLevel}:");
            
            while (queue.Count > 0)
            {
                // Get Node from queue
                Node current = queue.Dequeue();

                // Check if current Node level is greater than level tracker
                if (current.Level > currentLevel)
                {
                    currentLevel = current.Level;
                    Console.WriteLine($"\nLevel {currentLevel}:"); // Print new level header
                }

                // Print current node
                Console.WriteLine(
                    $"Node {current.Id}: Children [{string.Join(", ", current.Children.ConvertAll(c => c.Id))}] Level: {currentLevel}");


                // Enqueue child nodes
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            Console.WriteLine();
        }


        // Node class
        class Node
        {
            public int Id { get; }
            public int Level { get; }
            public List<Node> Children { get; }

            public Node(int id, int level)
            {
                Id = id;
                Level = level;
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