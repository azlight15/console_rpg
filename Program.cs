using System;

namespace Console_RPG;

public static class Program
{
    public static void Main()
    {
        Menu();
        GameConfirmed();
        while (PlayerStatistics.Hp > 0)
        {
            MonsterStatistics monster = CreateMonster();
            Battle.Start(monster);
            if (PlayerStatistics.Hp <= 0)
            {
                break;
            }

            Console.WriteLine("是否继续刷怪？（Y/N）");
            if (Console.ReadKey().KeyChar != 'Y' || Console.ReadKey().KeyChar != 'y')
            {
                break;
            }
        }
    }
    
    //主菜单
    private static void Menu()
    {
        Console.Clear();
        Console.WriteLine("===== 欢迎来玩Console RPG游戏 =====");
        Console.WriteLine("此游戏是控制台游戏，没有ui");
        Console.WriteLine("那么接下来请好好享受游戏吧！");
        Console.WriteLine("=================================");
        Console.Write("请输入你的名字（取了名字后不能更改！）：");
        PlayerStatistics.Name = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(PlayerStatistics.Name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n不能只输入空格或直接回车！请重新输入你的名字：");
            Console.ResetColor();
            PlayerStatistics.Name = Console.ReadLine()!;
        }
    }

    //游戏确认
    private static void GameConfirmed()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("正式游玩之前先看一下玩家状态");
        Console.WriteLine($"你的名字是：{PlayerStatistics.Name}");
        Console.WriteLine($"等级：{PlayerStatistics.Level}");
        Console.WriteLine($"HP：{PlayerStatistics.Hp}/{PlayerStatistics.MaxHp}");
        Console.WriteLine($"攻击值：{PlayerStatistics.Attack}");
        Console.WriteLine($"暴击值：{PlayerStatistics.CriticalHit}");
        Console.WriteLine($"那么祝你玩的开心，{PlayerStatistics.Name}勇者！");
        Console.WriteLine("=================================");
        Console.WriteLine("按下任意键开始游戏");
        Console.ReadKey();
    }
    
    //随机抽取怪物
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
                monster.CriticalHit = 8 * 1.5;
                break;
            case 2:
                monster.Name = "哥布林";
                monster.Level = 3;
                monster.Hp = 80;
                monster.MaxHp = 80;
                monster.Attack = 12;
                monster.CriticalHit = 12 * 1.5;
                break;
            case 3:
                monster.Name = "骷髅兵";
                monster.Level = 5;
                monster.Hp = 100;
                monster.MaxHp = 100;
                monster.Attack = 15;
                monster.CriticalHit = 15 * 1.5;
                break;
        }
        return monster;
    }
}