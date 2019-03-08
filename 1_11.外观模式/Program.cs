using System;

namespace _1_11.外观模式
{
    /// <summary>
    /// 以学生选课系统为例子演示外观模式的使用
    /// 学生选课模块包括功能有：
    /// 验证选课的人数是否已满
    /// 通知用户课程选择成功与否
    /// 客户端代码
    /// </summary>
    internal class Program
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        private static void Main(string[] args)
        {
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();


            /*
             优点：

                    外观模式对客户屏蔽了子系统组件，
                    从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。
                    外观模式实现了子系统与客户之间的松耦合关系，
                    而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。

            缺点：

                    如果增加新的子系统可能需要修改外观类或客户端的源代码，
                    这样就违背了”开——闭原则“（不过这点也是不可避免）。
             
             */



        }
    }

    /// <summary>
    /// 外观类
    /// </summary>
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;

        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }

        /// <summary>
        ///  注册课程 
        /// </summary>
        /// <param name="courseName">课程名</param>
        /// <param name="studentName">学生名</param>
        /// <returns></returns>
        public bool RegisterCourse(string courseName, string studentName)
        {
            //检查是否可以选择该课程
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            //发出通知
            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统

    /// <summary>
    /// 子系统A
    /// </summary>
    public class RegisterCourse
    {
        /// <summary>
        /// 检查是否可以选择该课程
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    /// <summary>
    /// 子系统B
    /// </summary>
    public class NotifyStudent
    {
        /// <summary>
        /// 发出通知
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }

    #endregion 子系统
}