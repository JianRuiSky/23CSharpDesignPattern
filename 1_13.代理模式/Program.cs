using System;

namespace _1_13.代理模式
{
    // 客户端调用
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.BuyProduct();
            Console.Read();

            /*
             
             优点：

                    代理模式能够将调用用于真正被调用的对象隔离，在一定程度上降低了系统的耦合度；
                    代理对象在客户端和目标对象之间起到一个中介的作用，这样可以起到对目标对象的保护。代理对象可以在对目标对象发出请求之前进行一个额外的操作，例如权限检查等。
             缺点：

                    由于在客户端和真实主题之间增加了一个代理对象，所以会造成请求的处理速度变慢
                    实现代理类也需要额外的工作，从而增加了系统的实现复杂度。
             
             */

        }
    }

    /// <summary>
    /// 抽象角色
    /// </summary>
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    /// <summary>
    /// 真实角色
    /// </summary>
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个IPhone和一台苹果电脑");
        }
    }

    /// <summary>
    /// 代理角色
    /// </summary>
    public class Friend : Person
    {
        // 引用真实主题实例
        private RealBuyPerson realSubject;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实实体对象的方法");
            if (realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }

            this.PreBuyProduct();
            // 调用真实主题方法
            realSubject.BuyProduct();
            this.PostBuyProduct();
        }

        // 代理角色执行的一些操作
        public void PreBuyProduct()
        {
            // 可能不知一个朋友叫这位朋友带东西，首先这位出国的朋友要对每一位朋友要带的东西列一个清单等
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }

        // 买完东西之后，代理角色需要针对每位朋友需要的对买来的东西进行分类
        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}