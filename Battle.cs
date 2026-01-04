//对战系统

using System;

namespace Console_RPG;

public static class Battle
{
    //开始对战与是否继续对战
    public static void StartBattle()
    {
        while (PlayerStatistics.Hp > 0)
        {
            var monster = MonsterFactory.Monster;
            Battle.Start(monster);
            if (PlayerStatistics.Hp <= 0)
            {
                Console.WriteLine("你的HP不足，帮你回到选择页面");
                Program.Loading();
            }

            Console.WriteLine("是否继续刷怪？（Y/N）");
            char choice = Console.ReadKey().KeyChar;
            if (choice != 'Y' && choice != 'y')
            {
                Program.Loading();
            }
        }
    }
    
    //正式对战，采取一换一战术
    private static void Start(MonsterStatistics monster)
    {
        Console.Clear();
        Console.WriteLine($"你遇到了{monster.Name}");
        Console.WriteLine($"等级：{monster.Level}");
        Console.WriteLine($"血量{monster.Hp}/{monster.MaxHp}");
        Console.WriteLine($"攻击力{monster.Attack}");
        Console.WriteLine($"暴击：{monster.CriticalHit}");
        Console.WriteLine("按任意键进入战斗！");
        Console.ReadKey();
        
        while (PlayerStatistics.Hp > 0 && monster.Hp > 0)
        {
            bool monsterCanBattle = true;
            
            Console.Clear();
            Console.WriteLine($"{PlayerStatistics.Name}");
            Console.WriteLine($"{PlayerStatistics.Level}");
            Console.WriteLine($"{PlayerStatistics.Hp}/{PlayerStatistics.MaxHp}");
            Console.WriteLine($"{PlayerStatistics.CriticalHit}");
            Console.WriteLine("=======================");
            Console.WriteLine($"{monster.Name}");
            Console.WriteLine($"{monster.Level}");
            Console.WriteLine($"{monster.Hp}/{monster.MaxHp}");
            Console.WriteLine($"{monster.CriticalHit}");
            Console.WriteLine("普通攻击（a/A） | 暴击（s/S） | 治疗（d/D） | 退出（f/F）");
            char battleOption = Console.ReadKey().KeyChar;
            switch (battleOption)
            {
                case 'A':
                case 'a':
                    //玩家进行普通攻击
                    monster.Hp-=PlayerStatistics.Attack;
                    Console.WriteLine($"你攻击了{monster.Name}，造成{PlayerStatistics.Attack}点伤害！");
                    break;
                case 'S':
                case 's':
                    //玩家进行暴击
                    monster.Hp-=PlayerStatistics.CriticalHit;
                    Console.WriteLine($"你攻击了{monster.Name}，造成{PlayerStatistics.CriticalHit}点伤害！");
                    break;
                case 'D': 
                case 'd':
                    //治疗
                    PlayerStatistics.Hp += PlayerStatistics.Treatment;
                    if (PlayerStatistics.Hp > PlayerStatistics.MaxHp)
                    {
                        PlayerStatistics.Hp = PlayerStatistics.MaxHp;
                    }
                    Console.WriteLine($"你治疗了自己，恢复 {PlayerStatistics.Treatment} HP");
                    break;
                case 'F': 
                case 'f':
                    Console.WriteLine("你选择了撤退");
                    monsterCanBattle = false;
                    break;
                default:
                    Console.WriteLine("无效操作！");
                    monsterCanBattle = false;
                    break;
            }
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"你击败了{monster.Name}！");
                Console.ResetColor();
                break;
            }
            
            
            
            //怪物反击
            if (monsterCanBattle || monster.Hp > 0)
            {
                PlayerStatistics.Hp-=monster.Attack;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{monster.Name} 反击你，造成 {monster.Attack} 点伤害");
                Console.ResetColor();
            }
            if (PlayerStatistics.Hp <= 0)
            {
                PlayerStatistics.Hp = 0;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n你倒下了……");
                Console.ResetColor();
                break;
            }
            
            

            Console.WriteLine("\n按任意键进入下一回合");
            Console.ReadKey();
        }
    }
}