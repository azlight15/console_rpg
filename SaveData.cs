//存档系统

using System;
using System.IO;
using System.Text.Json;

namespace Console_RPG;

public class SaveData
{
    public string Name { set; get; } = "";//名字
    public int Level { get; set; }//等级
    public double Exp { get; set; }//经验值
    public double Hp { get; set; }//血量（HP）
    public double MaxHp { get; set; }//最高血量
    public double Attack { get; set; }//攻击值
    public double Treatment { get; set; }//治疗值
}

public static class SaveManager
{
    private const string SaveFile = "save.json";

    public static void Save()
    {
        var data = new SaveData
        {
            Name = PlayerStatistics.Name,
            Level = PlayerStatistics.Level,
            Exp = PlayerStatistics.Exp,
            Hp = PlayerStatistics.Hp,
            MaxHp = PlayerStatistics.MaxHp,
            Attack = PlayerStatistics.Attack,
            Treatment = PlayerStatistics.Treatment
        };

        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        
        File.WriteAllText(SaveFile, json);
        Console.WriteLine("游戏已保存");
        Program.Loading();
    }

    public static void Load()
    {
        if (!File.Exists(SaveFile))
        {
            Console.WriteLine("没有找到存档文件");
        }
        
        string json=File.ReadAllText(SaveFile);
        var data = JsonSerializer.Deserialize<SaveData>(json);
        
        PlayerStatistics.Name = data!.Name;
        PlayerStatistics.Level = data.Level;
        PlayerStatistics.Exp = data.Exp;
        PlayerStatistics.Hp = data.Hp;
        PlayerStatistics.MaxHp = data.MaxHp;
        PlayerStatistics.Attack = data.Attack;
        PlayerStatistics.Treatment = data.Treatment;

        Console.WriteLine("存档读取成功！");
        Program.Loading();
    }
}