using System;

namespace _1_14模版方法模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 创建一个菠菜实例并调用模板方法
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            Console.Read();

            /*
             
             优点：

                    实现了代码复用
                    能够灵活应对子步骤的变化，符合开放-封闭原则

            缺点：
                    因为引入了一个抽象类，如果具体实现过多的话，
                    需要用户或开发人员需要花更多的时间去理清类之间的关系。

            附：
                    在.NET中模板方法的应用也很多，
                    例如我们在开发自定义的Web控件或WinForm控件时，
                    我们只需要重写某个控件的部分方法
             
             */

        }
    }

    public abstract class Vegetabel
    {
        // 模板方法，不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }

        // 第一步倒油
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }

        // 把油烧热
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }

        // 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetable();

        // 开发翻炒蔬菜
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }

    // 菠菜
    public class Spinach : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    // 大白菜
    public class ChineseCabbage : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}