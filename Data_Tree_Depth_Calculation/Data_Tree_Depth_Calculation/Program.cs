using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Program
{
    internal class Code
    {
        private const int maxBranchAmount = 2; //maximum amount of leafs that a branch can have
        private const int branchesToAdd = 50; //amount of branches that will be randomly added to the data tree
        static void Main(string[] args)
        {
            Branch branches = new Branch();
            Random rand = new Random();
            for(int i = 0; i < branchesToAdd; i++) //Randomly generates a data tree with a preset amount of branches
            {
                AddBranch(branches);
            }
            int maxTreeDepth = FindTreeDepth(branches, 0);
            Console.WriteLine("The maximum depth of the current randomly generated data tree is: {0}", maxTreeDepth);
        }
        class Branch
        {
            public List<Branch> branches { get; set; }

            public Branch(List<Branch> branches)
            {
                this.branches = branches;
            }
            public Branch()
            {
                this.branches = new List<Branch>();
            }
        }
        /// <summary>
        /// Adds a new branch to a random branch
        /// </summary>
        /// <param name="branch">data tree branch</param>
        static void AddBranch(Branch branch)
        {
            Random rnd = new Random();
            int randomBranchIndex = rnd.Next(maxBranchAmount);
            if (branch.branches.Count > randomBranchIndex)
            {
                AddBranch(branch.branches[randomBranchIndex]);
            }
            else
            {
                branch.branches.Add(new Branch());
            }
        }
        /// <summary>
        /// Finds the maximum depth of the data tree
        /// </summary>
        /// <param name="branch">data tree branch</param>
        /// <param name="currentDepth">the current depth</param>
        /// <returns>the maximum depth of the data tree</returns>
        static int FindTreeDepth(Branch branch, int currentDepth)
        {
            int depth = currentDepth + 1;
            int maxDepth = depth;
            foreach (Branch branch1 in branch.branches)
            {
                int branchDepth = FindTreeDepth(branch1, depth);
                if (branchDepth > maxDepth)
                {
                    maxDepth = branchDepth;
                }
            }
            return maxDepth;
        }
    }
}