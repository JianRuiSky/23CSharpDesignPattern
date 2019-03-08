using System;

namespace _3.工厂方法
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //-------------
            Creator creator1 = new TomatoScrambledEggsFactory();
            Food food1 = creator1.CreateFoodFactory();
            food1.Print();
            //-------------
            Creator creator2 = new ShreddedPorkWithPotatoesFactory();
            Food food3 = creator1.CreateFoodFactory();
            food1.Print();


            /*
             总结:
                1. 使用工厂方法实现的系统，
                   如果系统需要添加新产品时，
                   我们可以利用多态性来完成系统的扩展，
                   对于抽象工厂类和具体工厂中的代码都不需要做任何改动。

                2. 比如我们要增加一个  鱼香肉丝, 
                   我们只需要添加对应的 食物和工厂类 就可以

                   而不用像简单工厂模式中那样去修改工厂类中的实现
             */
        }
    }

    #region 工厂(饭店)

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        public abstract Food CreateFoodFactory();
    }

    /// <summary>
    /// 西红柿炒鸡蛋工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }

    /// <summary>
    /// 猪肉土豆丝工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }

    #endregion 工厂(饭店)

    #region 食物

    /// <summary>
    /// 食品抽象父类
    /// </summary>
    public abstract class Food
    {
        /// <summary>
        /// 输出 点菜信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒鸡蛋
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份 西红柿炒鸡蛋");
        }
    }

    /// <summary>
    /// 猪肉土豆丝
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份 猪肉土豆丝");
        }
    }

    #endregion 食物
}