using System;

namespace Console_RPG;

public static class Program
{
    private static bool _running = true;
    
    private static void Main()
    {
        Menu();
        GameConfirmed();
        while (_running)
        {
            OptionsMenu();
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
        Console.WriteLine($"那么祝你玩的开心，{PlayerStatistics.Name}勇者！");
        Console.WriteLine("=================================");
        Console.WriteLine("按下任意键开始游戏");
        Console.ReadKey();
    }

    //选择页面
    private static void OptionsMenu()
    {
        Console.WriteLine("=========================");
        Console.WriteLine("Console RPG");
        Console.WriteLine("请选择选项：");
        Console.WriteLine("1.开始对战");
        Console.WriteLine("2.升级");
        Console.WriteLine("3.治疗");
        Console.WriteLine("4.查看状态");
        Console.WriteLine("5.存档");
        Console.WriteLine("6.读档");
        Console.WriteLine("7.退出游戏");
        Console.WriteLine("==========================");
        Console.Write("请选择选项：");
        int options = Convert.ToInt32(Console.ReadLine());
        switch (options)
        {
            case 1:
                Battle.StartBattle();//指向Battle.cs文件
                break;
            case 2:
                UpLevel.GainExp(100);//指向LevelUp.cs文件
                break;
            case 3:
                Heal();
                break;
            case 4:
                ShowStatus();
                break;
            case 5:
                SaveManager.Save();
                break;
            case 6:
                SaveManager.Load();
                break;
            case 7:
                Console.WriteLine("欢迎再次玩Console RPG，谢谢");
                Console.WriteLine("那么下次再见，勇者！");
                _running = false;
                break;
            default:
                while (options > 7 || options < 0)
                {
                    Console.Write("\n输入错误，请重新输入：");
                    options = Convert.ToInt32(Console.ReadLine());
                }
                break;
        }
    }

    //治疗（第3选项）
    private static void Heal()
    {
        PlayerStatistics.Hp += PlayerStatistics.Treatment;
        if (PlayerStatistics.Hp > PlayerStatistics.MaxHp)
        {
            PlayerStatistics.Hp = PlayerStatistics.MaxHp;
        }
        Console.WriteLine($"你治疗了自己，恢复 {PlayerStatistics.Treatment} HP");

        Loading();
    }
    
    //查看状态（第4选项）
    private static void ShowStatus()
    {
        Console.WriteLine($"你的名字是：{PlayerStatistics.Name}");
        Console.WriteLine($"等级：{PlayerStatistics.Level}");
        Console.WriteLine($"Exp:{PlayerStatistics.Exp}/{PlayerStatistics.ExpToNextLevel}");
        Console.WriteLine($"HP：{PlayerStatistics.Hp}/{PlayerStatistics.MaxHp}");
        Console.WriteLine($"攻击值：{PlayerStatistics.Attack}");
                
        Loading();
    }

    //等待
    public static void Loading()
    {
        Console.WriteLine("按下任意键回到选择页面");
        Console.ReadKey();
    }
}