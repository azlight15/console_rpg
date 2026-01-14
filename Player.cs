namespace Console_RPG;

//玩家数值
public static class PlayerStatistics
{
    public static string Name = null!;//名字
    public static int Level = 1;//等级
    public static double Exp = 0;//经验值
    public static double ExpToNextLevel => Level * 100;//经验值转换为等级
    public static double Hp = 100;//初始血量（HP）
    public static double MaxHp = 100;//初始最高血量
    public static double Attack = 15;//初始攻击值
    public static double Treatment = 50;//治疗值
}