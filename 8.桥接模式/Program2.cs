using System;
using System.Collections.Generic;

namespace _8.桥接模式
{
    internal class Program2
    {
        // 桥接模式 ------ 三层架构中的应用
        // 客户端调用
        // 类似Web应用程序
        private static void Main(string[] args)
        {
            BaseBLL customers = new BLL("ShangHai");
            customers.dal = new DAL();

            customers.Add("小六");

            customers.Delete("王五");

            customers.Update("Learning_Hard");

            customers.ShowAll();

            Console.Read();
        }
    }

    #region BLL

    public class BaseBLL
    {
        private string city;

        public BaseBLL(string city)
        {
            this.city = city;
        }

        // 属性
        public BaseDAL dal { get; set; }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="name"></param>
        public virtual void Add(string name)
        {
            dal.AddRecord(name);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name"></param>
        public virtual void Delete(string name)
        {
            dal.DeleteRecord(name);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        public virtual void Update(string name)
        {
            dal.UpdateRecord(name);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual string Get(int index)
        {
            return dal.GetRecord(index);
        }

        /// <summary>
        /// 显示所有
        /// </summary>
        public virtual void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0}的顾客有：", city);
            dal.ShowAllRecords();
        }
    }

    public class BLL : BaseBLL
    {
        public BLL(string city)
            : base(city) { }

        // 重写方法
        public override void ShowAll()
        {
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    #endregion BLL

    #region DAL

    public abstract class BaseDAL
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="name"></param>
        public abstract void AddRecord(string name);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name"></param>
        public abstract void DeleteRecord(string name);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        public abstract void UpdateRecord(string name);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract string GetRecord(int index);

        /// <summary>
        /// 显示所有
        /// </summary>
        public abstract void ShowAllRecords();
    }

    public class DAL : BaseDAL
    {
        // 字段
        private List<string> customers = new List<string>();

        public DAL()
        {
            // 实际业务中从数据库中读取数据再填充列表
            customers.Add("Learning Hard");
            customers.Add("张三");
            customers.Add("李四");
            customers.Add("王五");
        }

        // 重写方法
        public override void AddRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            customers.Remove(name);
        }

        public override void UpdateRecord(string updatename)
        {
            customers[0] = updatename;
        }

        public override string GetRecord(int index)
        {
            return customers[index];
        }

        public override void ShowAllRecords()
        {
            foreach (string name in customers)
            {
                Console.WriteLine(" " + name);
            }
        }
    }

    #endregion DAL
}