using System;

namespace Console_RPG;

public static class UpLevel
{
    public static void GainExp(int getExp)
    {
        PlayerStatistics.Exp += getExp;
        Console.WriteLine($"获得经验{getExp}点");

        while (PlayerStatistics.Exp >= PlayerStatistics.ExpToNextLevel)
        {
            LevelUp();
        }
    }

    private static void LevelUp()
    {
        PlayerStatistics.Exp-= PlayerStatistics.ExpToNextLevel;
        PlayerStatistics.Level++;

        PlayerStatistics.MaxHp += 20;//最大生命++
        PlayerStatistics.Attack += 5;//攻击值++
        PlayerStatistics.CriticalHit += 1;//暴击++
        PlayerStatistics.Hp = PlayerStatistics.MaxHp;//HP回满
        PlayerStatistics.ExpToNextLevel += 50;//下一级需要的经验值

        Console.WriteLine("升级了！");
        Console.WriteLine($"当前等级：{PlayerStatistics.Level}");
        Console.WriteLine("最大HP +20\n攻击值 +5\nHP已回满");
        
        Program.Loading();
    }
}