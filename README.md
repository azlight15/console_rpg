# console_rpg
一个控制台对战游戏，想玩就下载源码（下载后记得看看ConsoleRpgReadme.md）。

目前不会写md文件，抱歉

游戏名：Console_RPG

.NET版本：10.0

作者：AzLight15

***

## 这个项目有哪些系统？

现在有以下系统：

1.`Program.cs`

这是主程序文件，里面有：
主函数——`Program.Main`、
开始菜单——`Program.StartMenu`、
确认菜单——`Program.GameConfirmed`、
选择页面——`Program.OptionsMenu`

架构是这样子：

```csharp
public static class Program
{
    private static bool _running = true;//游戏运行状态
    
    private static void Main()
    {
        StartMenu();
        GameConfirmed();
        while (_running)
        {
            OptionsMenu();
        }
    }
```

2.`Battle.cs`

这是对战系统

里面有两个方法：对战确认——`StartBattle`和对战系统——`Battle`

流程：

从`Program.OptionsMenu`（选择页面）选择**开始对战**后，会跳到`StartBattle`方法

这时会判断你的Hp值是不是大于等于0，判断通过后从怪物工厂——`MonsterFactory.cs`导入并显示怪物信息，之后转到`Battle`方法进行一换一对战

对战完成后，同时获得经验（Battle部分）并自动升级你的等级，然后回到`StartBattle`方法进行询问是否继续对战

填`y`（大小写都可以）继续，否则回到选择页面

3.`LevelUp.cs`

这是升级系统，里面有获得经验（LevelUp部分）和升级方法

不知道怎么描述，上个图吧（

![](LevelUp.png)

~~总感觉像是上了双重保险~~
