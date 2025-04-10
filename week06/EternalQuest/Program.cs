// - Added "ProgressGoal" which allows tracking progress towards a larger goal with incremental points.
// - Implemented a "Leveling System" where the player gains levels based on their total score and gets a bonus multiplier.

using System;

    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }