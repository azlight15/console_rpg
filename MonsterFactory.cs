//怪物工厂

using System;

namespace Console_RPG;

public static class MonsterFactory
{
    public static MonsterStatistics Monster => CreateMonster();
    private static MonsterStatistics CreateMonster()
    {
        Random random = new Random();
        int type = random.Next(1, 4);//1~3
        bool isElite = Random.Shared.Next(100) < 10;
        int playerLevel = PlayerStatistics.Level;//玩家预设等级导入到playerLevel变量
        
        MonsterStatistics monster = new MonsterStatistics();

        switch (type)
        {
            case 1:
                monster.Name = "史莱姆";
                monster.Level = Math.Max(1, playerLevel - 1);
                monster.MaxHp = 30 + monster.Level * 4;
                monster.Attack = 5 + monster.Level * 1;
                monster.ExpReward = 30 + monster.Level * 10;
                break;
            case 2:
                monster.Name = "哥布林";
                monster.Level = playerLevel;
                monster.MaxHp = 50 + monster.Level * 5;
                monster.Attack = 8 + monster.Level * 2;
                monster.ExpReward = 50 + monster.Level * 15;
                break;
            case 3:
                monster.Name = "骷髅兵";
                monster.Level = playerLevel + 1;
                monster.MaxHp = 70 + monster.Level * 6;
                monster.Attack = 10 + monster.Level * 3;
                monster.ExpReward = 70 + monster.Level * 20;
                break;
        }

        if (isElite)
        {
            monster.Name = "[精英]" + monster.Name;
            monster.Level = playerLevel + 3;
            monster.MaxHp *= 1.5;
            monster.Hp = monster.MaxHp;
            monster.Attack *= 1.5;
            monster.ExpReward *= 1.5;
        }

        monster.Hp = monster.MaxHp;
        return monster;
    }
}