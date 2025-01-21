namespace BaseArea51;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Elevator elevator = new();
        List<Agent> agents = new()
        {
            new Agent("Agent A", SecurityLevel.Confidential, Floor.Ground),
            new Agent("Agent B", SecurityLevel.Secret, Floor.Secret),
            new Agent("Agent C", SecurityLevel.TopSecret, Floor.Experimental)
        };

        while (true)
        {
            Console.WriteLine("Current state:");
            foreach (var agent in agents)
            {
                Console.WriteLine($"{agent.Name} is at '{agent.CurrentFloor}' floor with {agent.Clearance} clearance.");
            }

            Console.WriteLine("Choose an agent (A, B, C), case-ignored:");
            string agentChoice = Console.ReadLine()?.ToUpper();
            Agent selectedAgent = agents.FirstOrDefault(a => a.Name.EndsWith(agentChoice));

            if (selectedAgent == null)
            {
                Console.WriteLine("Invalid agent name. Please, try again!");
                continue;
            }

            Console.WriteLine($"{selectedAgent.Name} is now at '{selectedAgent.CurrentFloor}' floor.");
            Console.WriteLine("Choose a target floor [ 0 : Ground , 1 : Secret , 2 : Experimental , 3 : TopSecret ]:");
            if (!int.TryParse(Console.ReadLine(), out int floorChoice) || floorChoice < 0 || floorChoice > 3)
            {
                Console.WriteLine("Invalid floor index. Please, try again.");
                continue;
            }

            Floor targetFloor = (Floor)floorChoice;

            Console.WriteLine($"{selectedAgent.Name} is calling the elevator to go to '{targetFloor}' floor.");
            await elevator.CallElevator(selectedAgent, targetFloor);

            Console.WriteLine("Do you want to continue? (y/n):");
            if (Console.ReadLine()?.ToLower() != "y")
            {
                Console.WriteLine("Exiting simulation.");
                break;
            }
        }
    }
}