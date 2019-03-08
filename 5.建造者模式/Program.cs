using System;
using System.Collections.Generic;

namespace _5.建造者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板让小陈去装电脑
            director.Construct(b1);
            // 小陈 搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            //电脑配置
            computer1.Show();

            //--------------------------------------

            // 老板让小鹏去装电脑
            director.Construct(b2);
            // 小鹏 搬来组装好的电脑
            Computer computer2 = b2.GetComputer();
            //电脑配置
            computer2.Show();


            Console.Read();



            /*
             总结:

                1. 在建造者模式中，指挥者是直接与客户端打交道的，指挥者将客户端创建产品的请求划分为对各个部件的建造请求，再将这些请求委派到具体建造者角色，具体建造者角色是完成具体产品的构建工作的，却不为客户所知道。
                2. 建造者模式主要用于“分步骤来构建一个复杂的对象”，其中“分步骤”是一个固定的组合过程，而复杂对象的各个部分是经常变化的（也就是说电脑的内部组件是经常变化的，这里指的的变化如硬盘的大小变了，CPU由单核变双核等）。
                3. 产品不需要抽象类，由于建造模式的创建出来的最终产品可能差异很大，所以不大可能提炼出一个抽象产品类。
                4. 抽象工厂模式解决了“系列产品”的需求变化，而建造者模式解决的是 “产品部分” 的需要变化。
                5. 由于建造者隐藏了具体产品的组装过程，所以要改变一个产品的内部表示，只需要再实现一个具体的建造者就可以了，从而能很好地应对产品组成组件的需求变化。
             
             
             */



        }
    }

    /// <summary>
    /// 装机人员 难道会自愿地去组装嘛，谁不想休息的，
    /// 这必须有一个人叫他们去组装才会去的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// 指挥创建过程类
    /// </summary>
    public class Director
    {
        /// <summary>
        /// 组装电脑
        /// </summary>
        /// <param name="builder"></param>
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    #region 组装者

    /// <summary>
    /// 抽象组装者
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 装CPU
        /// </summary>
        public abstract void BuildPartCPU();

        /// <summary>
        /// 装主板
        /// </summary>
        public abstract void BuildPartMainBoard();

        /// <summary>
        /// 把装好的电脑 搬过来
        /// </summary>
        /// <returns></returns>
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 装机小陈
    /// </summary>
    public class ConcreteBuilder1 : Builder
    {
        private Computer computer = new Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 装机小鹏
    /// </summary>
    public class ConcreteBuilder2 : Builder
    {
        private Computer computer = new Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    #endregion 组装者

    #region 电脑操作类 (供装机人员 调用)

    /// <summary>
    /// 电脑操作类
    /// </summary>
    public class Computer
    {
        // 电脑组件集合
        private IList<string> parts = new List<string>();

        /// <summary>
        /// 组装电脑
        /// </summary>
        /// <param name="part"></param>
        public void Add(string part)
        {
            parts.Add(part);
        }

        /// <summary>
        /// 显示电脑 配置
        /// </summary>
        public void Show()
        {
            Console.WriteLine("装好的电脑配置如下 ↓");
            foreach (string part in parts)
            {
                Console.WriteLine("组件 :" + part);
            }

            Console.WriteLine("----------------");
        }
    }

    #endregion 电脑操作类
}