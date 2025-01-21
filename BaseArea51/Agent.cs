namespace BaseArea51;

using System;
using System.Collections.Generic;

public class Agent
{
    public string Name { get; set; }
    public SecurityLevel Clearance { get; set; }
    public Floor CurrentFloor { get; set; }
    private int FailedAttempts { get; set; } = 0;

    public Agent(string name, SecurityLevel clearance, Floor startFloor)
    {
        Name = name;
        Clearance = clearance;
        CurrentFloor = startFloor;
    }

    public bool CanAccess(Floor floor)
    {
        return Clearance switch
        {
            SecurityLevel.Confidential => floor == Floor.Ground,
            SecurityLevel.Secret => floor == Floor.Ground || floor == Floor.Secret,
            SecurityLevel.TopSecret => true,
            _ => false
        };
    }

    public void IncrementFailedAttempts()
    {
        FailedAttempts++;
        if (FailedAttempts >= 3)
        {
            Console.WriteLine($"{Name} has made 3 failed attempts! Agent can access: {GetAccessibleFloors()}.");
            FailedAttempts = 0; // Reset after notifying
        }
    }

    private string GetAccessibleFloors()
    {
        var accessible = new List<string>();
        foreach (Floor floor in Enum.GetValues(typeof(Floor)))
        {
            if (CanAccess(floor))
            {
                accessible.Add(floor.ToString());
            }
        }
        return string.Join(", ", accessible);
    }
}