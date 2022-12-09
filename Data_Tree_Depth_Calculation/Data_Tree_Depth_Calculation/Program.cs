using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Program
{
    internal class Code
    {
        const int maxBranchAmount = 2; //maximum amount of leafs that a branch can have
        const int branchesToAdd = 50; //amount of branches that will be randomly added to the data tree
        static void Main(string[] args)
        {
            Branch branches = new Branch();
            Random rand = new Random();
            for(int i = 0; i < branchesToAdd; i++)
            {
                branches.AddBranch();
            }
            int maxTreeDepth = branches.FindTreeDepth(0);
            Console.WriteLine("The maximum depth of the current randomly generated data tree is: {0}", maxTreeDepth);

            branches.PrintTreeToConsole();
        }
        class Branch
        {
            List<Branch> branches = new List<Branch>();

            /// <summary>
            /// Recursively adds a set amount of branches to the data tree, however the depth is never known
            /// </summary>
            public void AddBranch()
            {
                Random rnd = new Random();
                int randomBranchIndex = rnd.Next(maxBranchAmount);
                if (branches.Count > randomBranchIndex)
                {
                    branches[randomBranchIndex].AddBranch();
                }
                else
                {
                    branches.Add(new Branch());
                }
            }
            public int FindTreeDepth(int currentDepth)
            {
                int depth = currentDepth + 1;
                int maxDepth = depth;
                foreach (Branch branch in branches)
                {
                    int branchDepth = branch.FindTreeDepth(depth);
                    if(branchDepth > maxDepth)
                    {
                        maxDepth = branchDepth;
                    }
                }
                return maxDepth;
            }
            public void PrintTreeToConsole()
            {
                
            }
        }
    }
}