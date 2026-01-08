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
        MonsterStatistics monster = new MonsterStatistics();

        switch (type)
        {
            case 1:
                monster.Name = "史莱姆";
                monster.Level = 1;
                monster.Hp = 50;
                monster.MaxHp = 50;
                monster.Attack = 8;
                monster.CriticalHit = 8 * 2;
                break;
            case 2:
                monster.Name = "哥布林";
                monster.Level = 3;
                monster.Hp = 80;
                monster.MaxHp = 80;
                monster.Attack = 12;
                monster.CriticalHit = 12 * 2;
                break;
            case 3:
                monster.Name = "骷髅兵";
                monster.Level = 5;
                monster.Hp = 100;
                monster.MaxHp = 100;
                monster.Attack = 15;
                monster.CriticalHit = 15 * 2;
                break;
        }
        return monster;
    }
}