using System;

namespace _4.抽象工厂
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            // 南昌工厂 制作南昌的鸭脖和鸭架
            AbstractFactory nanChangFactory = new NanChangFactory();
            nanChangFactory.CreateYaBo().Print();
            nanChangFactory.CreateYaJia().Print();

            // 上海工厂 制作上海的鸭脖和鸭架
            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();
            shangHaiFactory.CreateYaJia().Print();


            /*
             总结:
                  1.缺点
                    抽象工厂模式很难支持新种类产品的变化。
                    这是因为抽象工厂接口中已经确定了可以被创建的产品集合，
                    如果需要添加新产品，此时就必须去修改抽象工厂的接口，
                    这样就涉及到抽象工厂类的以及所有子类的改变，
                    这样也就违背了“开发——封闭”原则。

                2.优点
                    抽象工厂模式将具体产品的创建延迟到具体工厂的子类中，
                    这样将对象的创建封装起来，
                    可以减少客户端与具体产品类之间的依赖，
                    从而使系统耦合度低，
                    这样更有利于后期的维护和扩展
             
             */
        }
    }

    #region 工厂

    /// <summary>
    /// 抽象工厂类，提供创建两个不同地方的鸭架和鸭脖的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了绝味中鸭脖和鸭架的创建接口
        public abstract YaBo CreateYaBo();

        public abstract YaJia CreateYaJia();
    }

    /// <summary>
    /// 南昌工厂 负责制作南昌的鸭脖和鸭架
    /// </summary>
    public class NanChangFactory : AbstractFactory
    {
        // 制作南昌鸭脖
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }

        // 制作南昌鸭架
        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }

    /// <summary>
    /// 上海工厂 负责制作上海的鸭脖和鸭架
    /// </summary>
    public class ShangHaiFactory : AbstractFactory
    {
        // 制作上海鸭脖
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }

        // 制作上海鸭架
        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }

    #endregion 工厂

    #region 食物

    #region 鸭脖

    /// <summary>
    /// 鸭脖抽象类，供每个地方的鸭脖类继承
    /// </summary>
    public abstract class YaBo
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 南昌的鸭脖类，因为江西人喜欢吃辣的，所以南昌的鸭脖稍微会比上海做的辣
    /// </summary>
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    /// <summary>
    /// 上海的鸭脖没有南昌的鸭脖做的辣
    /// </summary>
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭脖");
        }
    }

    #endregion 鸭脖

    #region 鸭架

    /// <summary>
    /// 鸭架抽象类，供每个地方的鸭架类继承
    /// </summary>
    public abstract class YaJia
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 南昌的鸭架
    /// </summary>
    public class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭架子");
        }
    }

    /// <summary>
    /// 上海的鸭架
    /// </summary>
    public class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭架子");
        }
    }

    #endregion 鸭架

    #endregion 食物
}