namespace BaseArea51;

using System;
using System.Threading;
using System.Threading.Tasks;

public class Elevator
{
    public Floor CurrentFloor { get; private set; } = Floor.Ground;
    private bool IsBusy = false;
    private readonly object LockObject = new();

    public async Task CallElevator(Agent agent, Floor targetFloor)
    {
        lock (LockObject)
        {
            if (IsBusy)
            {
                Console.WriteLine($"{agent.Name}: Waiting for elevator.");
                Monitor.Wait(LockObject);
            }
            IsBusy = true;
        }

        await MoveToFloor(agent.CurrentFloor);
        Console.WriteLine($"Elevator arrived at '{agent.CurrentFloor}' floor for {agent.Name}.");
        await MoveToFloor(targetFloor);

        if (agent.CanAccess(targetFloor))
        {
            Console.WriteLine($"{agent.Name} exited at '{targetFloor}' floor.");
            agent.CurrentFloor = targetFloor;
        }
        else
        {
            Console.WriteLine($"{agent.Name} cannot access '{targetFloor} floor'. Can not exit elevator.");
            agent.IncrementFailedAttempts();
        }

        lock (LockObject)
        {
            IsBusy = false;
            Monitor.Pulse(LockObject);
        }
    }

    private async Task MoveToFloor(Floor targetFloor)
    {
        while (CurrentFloor != targetFloor)
        {
            await Task.Delay(1000);

            CurrentFloor = CurrentFloor < targetFloor
                ? CurrentFloor + 1
                : CurrentFloor - 1;

            Console.WriteLine($"Elevator moving... Now at {CurrentFloor}.");
        }
    }
}