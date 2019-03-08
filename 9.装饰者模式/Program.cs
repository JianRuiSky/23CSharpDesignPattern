using System;

namespace _9.装饰者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            // 我买了个苹果手机
            Phone phone = new ApplePhone();

            // 现在想贴膜了
            Decorator applePhoneWithSticker = new Sticker(phone);
            // 扩展贴膜行为
            applePhoneWithSticker.Print();

            Console.WriteLine("----------------------\n");

            // 现在我想有挂件了
            Decorator applePhoneWithAccessories = new Accessories(phone);
            // 扩展手机挂件行为
            applePhoneWithAccessories.Print();

            Console.WriteLine("----------------------\n");

            // 现在我同时有贴膜和手机挂件了
            Sticker sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();



            Console.ReadLine();


            /*
             
             优点：
                    装饰这模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活
                    通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合
                    装饰者模式有很好地可扩展性

             缺点：
                    装饰者模式会导致设计中出现许多小对象，
                    如果过度使用，会让程序变的更复杂。
                    并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。
             
             
             */

        }
    }

    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }

    /// <summary>
    /// 苹果手机，即装饰着模式中的具体组件类
    /// </summary>
    public class ApplePhone : Phone
    {
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Photo
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone;

        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }

    /// <summary>
    /// 贴膜，即具体装饰者
    /// </summary>
    public class Sticker : Decorator
    {
        /// <summary>
        /// 贴膜
        /// </summary>
        /// <param name="p"></param>
        public Sticker(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddSticker();
        }

        /// <summary>
        /// 添加贴膜
        /// </summary>
        public void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    /// <summary>
    /// 手机挂件
    /// </summary>
    public class Accessories : Decorator
    {
        /// <summary>
        /// 手机挂件
        /// </summary>
        /// <param name="p"></param>
        public Accessories(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddAccessories();
        }

        /// <summary>
        /// 添加挂件
        /// </summary>
        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }
}