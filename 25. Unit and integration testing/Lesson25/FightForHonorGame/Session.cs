using FightForHonorGame.Personages;
using FightForHonorGame.Personages.Body;

namespace FightForHonorGame;

// High-coupled, low-cohesion code. We should make it more testable.
// 1. Separate players creation and fight stage
// 2. Move logic to distinct component with a strict interface
// 3. Use abstractions in method signatures if possible
// 4. Session should contain only flow actions ("create players", "start next turn", "call a winner" etc)
public static class Session
{
    public static void Run()
    {
        Console.WriteLine("Enter name of the first player:");
        var playerOneName = Console.ReadLine() ?? "Player1";
        
        Console.WriteLine("Enter name of the second player:");
        var playerTwoName = Console.ReadLine() ?? "Player2";

        const float initialHealth = 100;
        var playerOne = new Character(playerOneName, initialHealth);
        var playerTwo = new Character(playerTwoName, initialHealth);

        bool hasWinner = false;
        const float defaultDamage = 10.0f;
        while (!hasWinner)
        {
            SetupDefence(playerOne, playerTwo);
            Attack(playerOne, playerTwo);
            Attack(playerTwo, playerOne);
        }

        var winner = CheckWinner(playerOne, playerTwo);
        if (winner == null)
        {
            Console.WriteLine("It's a draw!");
            return;
        }
        
        Console.WriteLine($"{winner.Name} is winner!");
        return;
        
        void SetupDefence(ICharacter pOne, ICharacter pTwo)
        {
            var playerOneDefenceTarget = GetTarget($"{pOne.Name}, set up your defence!");
            pOne.Defend(playerOneDefenceTarget);
            
            var playerTwoDefenceTarget = GetTarget($"{pTwo.Name}, set up your defence!");
            pTwo.Defend(playerTwoDefenceTarget);
        }
        
        void Attack(ICharacter player, ICharacter opponent)
        {
            var playerOneAttackTarget = GetTarget($"{player.Name}, choose target to attack!");
            opponent.ApplyAttack(playerOneAttackTarget, defaultDamage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name} attacks {playerOneAttackTarget}." +
                              $" {opponent.Name} health is {opponent.Health} now");
            Console.ResetColor();
            
            if (opponent.IsAlive) return;

            hasWinner = true;
        }

        ICharacter? CheckWinner(ICharacter pOne, ICharacter pTwo)
        {
            var players = new[] { pOne, pTwo };
            return players.FirstOrDefault(p => p.IsAlive);
        }
        
        BodyPartType GetTarget(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"1 - {BodyPartType.Head}");
            Console.WriteLine($"2 - {BodyPartType.LeftHand}");
            Console.WriteLine($"3 - {BodyPartType.RightHand}");
            Console.WriteLine($"4 - {BodyPartType.Torso}");
            Console.WriteLine($"5 - {BodyPartType.LeftLeg}");
            Console.WriteLine($"6 - {BodyPartType.RightLeg}");

            var bodyPartType = Console.ReadLine() switch
            {
                "1" => BodyPartType.Head,
                "2" => BodyPartType.LeftHand,
                "3" => BodyPartType.RightHand,
                "4" => BodyPartType.Torso,
                "5" => BodyPartType.LeftLeg,
                "6" => BodyPartType.RightLeg,
                _ => throw new InvalidOperationException("Unknown target")
            };

            return bodyPartType;
        }
    }
}