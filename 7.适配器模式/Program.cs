using System;

namespace _7.适配器模式
{
    //类的适配器
    //Program2 是 对象适配器
    internal class Program
    {
        /// <summary>
        /// 客户端，客户想要把2个孔的插头 转变成三个孔的插头，这个转变交给适配器就好
        /// 既然适配器需要完成这个功能，所以它必须同时具体2个孔插头和三个孔插头的特征
        /// </summary>
        private static void Main(string[] args)
        {
            /// 这里以插座和插头的例子来诠释适配器模式
            /// 现在我们买的电器插头是2个孔，但是我们买的插座只有3个孔的
            /// 这是我们想把电器插在插座上的话就需要一个电适配器

            // 现在客户端可以通过电适配要使用2个孔的插头了
            IThreeHole threehole = new PowerAdapter();
            threehole.Request();
            Console.ReadLine();

            /*
             类的适配器模式：

                优点：
                
                         可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”
                         可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类
                         仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。
                缺点：
                
                        用一个具体的Adapter类对Adaptee和Target进行匹配，当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。因为类的适配器模式中没有引入Adaptee的实例，光调用this.SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。
                        采用了 “多继承”的实现方式，带来了不良的高耦合。
             
             
             */
        }
    }

    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public abstract class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，接口要放在类的后面
    /// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
    /// </summary>
    public class PowerAdapter : TwoHole, IThreeHole
    {
        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public void Request()
        {
            // 调用两个孔插头方法
            this.SpecificRequest();
        }
    }
}