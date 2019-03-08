using System;

namespace _2.简单工厂
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Food food1 = FoodSimpleFactory.CreateFood("猪肉土豆丝");
            food1.Print();

            Food food2 = FoodSimpleFactory.CreateFood("西红柿炒鸡蛋");
            food2.Print();


            /*
             总结:
                将 实例化的过程放在一个 类中.
                通过传入不同的参数
                使用if 进行区分.  返回所需要的实例

            缺点:
                每次 增加菜品的时候都需要 修改 食品加工厂
             
             */

        }
    }

    /// <summary>
    /// 食品加工厂
    /// 
    /// 顾客充当客户端，负责调用简单工厂来生产对象
    /// 即客户点菜，厨师（相当于简单工厂）负责烧菜(生产的对象)
    /// </summary>
    public class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if ("猪肉土豆丝" == type)
            {
                food = new ShreddedPorkWithPotatoes();
            }
            else if ("西红柿炒鸡蛋" == type)
            {
                food = new TomatoScrambledEggs();
            }
            return food;
        }
    }

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