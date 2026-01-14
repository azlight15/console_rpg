using System;

namespace Console_RPG;

public static class UpLevel
{
    public static void GainExp(double getExp)
    {
        PlayerStatistics.Exp += getExp;
        Console.WriteLine($"获得经验{getExp}点");

        while (PlayerStatistics.Exp >= PlayerStatistics.ExpToNextLevel)
        {
            LevelUp();
        }
    }

    //等级升级
    private static void LevelUp()
    {
        while (PlayerStatistics.Exp >= PlayerStatistics.ExpToNextLevel)
        {
            PlayerStatistics.Exp-= PlayerStatistics.ExpToNextLevel;
            PlayerStatistics.Level++;
            
            PlayerStatistics.MaxHp += 20;//最大生命++
            PlayerStatistics.Attack += 5;//攻击值++
            PlayerStatistics.Hp = PlayerStatistics.MaxHp;//HP回满
        

            Console.WriteLine("升级了！");
            Console.WriteLine($"当前等级：{PlayerStatistics.Level}");
            Console.WriteLine("最大HP +20\n攻击值 +5\nHP已回满");
        
            Program.Loading();
        }
    }
}