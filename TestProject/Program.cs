// You must use either the do-while statement or the while statement as an outer game loop.
// The hero and the monster start with 10 health points.
// All attacks are a value between 1 and 10.
// The hero attacks first.
// Print the amount of health the monster lost and their remaining health.
// If the monster's health is greater than 0, it can attack the hero.
// Print the amount of health the hero lost and their remaining health.
// Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
// Print the winner.

int heroHP = 10;
int monsterHP = 10;
Random damage = new Random();
int min = 1;
int max = 10;
int attackDamage = 0;
bool heroTurn = true;
string winner = "";

do
{
    if (heroTurn)
    {
        attackDamage = damage.Next(min, max + 1);
        monsterHP -= attackDamage;
        Console.WriteLine($"Monster was damaged and lost {attackDamage} health and now has {monsterHP} health.");
    }
    else
    {
        attackDamage = damage.Next(min, max + 1);
        heroHP -= attackDamage;
        Console.WriteLine($"Hero was damaged and lost {attackDamage} health and now has {heroHP} health.");
    }

    heroTurn = !heroTurn;
} while (heroHP > 0 && monsterHP > 0);

winner = heroHP > 0 ? "Hero" : "Monster";

Console.WriteLine($"Winner: {winner}!");