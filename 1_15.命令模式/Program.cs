using System;

namespace _1_15.命令模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoke invoke = new Invoke(command);

            // 院领导发出命令
            invoke.ExecuteCommand();


            /*
                 优点:
                    命令模式使得新的命令很容易被加入到系统里。
                    可以设计一个命令队列来实现对请求的Undo和Redo操作。
                    可以较容易地将命令写入日志。
                    可以把命令对象聚合在一起，合成为合成命令。合成命令式合成模式的应用。

                缺点:
                    使用命令模式可能会导致系统有过多的具体命令类。
                    这会使得命令模式在这样的系统里变得不实际。
             
             
             */

        }
    }

    /// <summary>
    ///  教官，负责调用命令对象执行请求
    /// </summary>
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    /// <summary>
    /// 命令抽象类
    /// </summary>
    public abstract class Command
    {
        // 命令应该知道接收者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        // 命令执行方法
        public abstract void Action();
    }

    /// <summary>
    /// 具体命令
    /// </summary>
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Action()
        {
            // 调用接收的方法，因为执行命令的是学生
            _receiver.Run1000Meters();
        }
    }

    /// <summary>
    /// 命令接收者——学生
    /// </summary>
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }

   
}