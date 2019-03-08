using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.单例模式
{
    class Program
    {
        //https://blog.csdn.net/sinat_15155817/article/details/79040541
        static void Main(string[] args)
        {
            //错误信息: 不可访问,因为它具有一定的保护级别 (私有构造函数可以 防止外界实例化)
            //Singleton singleton = new Singleton();

            //正确方法
            Singleton singleton = Singleton.GetInstance();

            
           /*
            
             总结: 
                1.一个私有类的静态变量
                2.一个私有构造函数(防止外界实例化该类)
                3.一个公开的静态方法 返回类的实例

                4. 一个私有静态只读变量
                5. 对静态变量加锁
                6. 锁的前后判断 实例是否被创建,如果被创建 直接返回现有的实例             
             
             */



            Console.ReadLine();
        }
    }
}
