namespace Console_RPG;

//玩家数值
public static class PlayerStatistics
{
    public static string Name = null!;//名字
    public static int Level = 1;//等级
    public static int Exp = 0;//经验值
    public static int ExpToNextLevel = 100;//经验值转换为等级
    public static int Hp = 100;//初始血量（HP）
    public static int MaxHp = 100;//初始最高血量
    public static int Attack = 15;//初始攻击值
    public static int CriticalHit = Attack * 2;//暴击值
    public static int Treatment = 20;//治疗值
}