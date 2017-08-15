using System;
using System.IO;
using System.ServiceProcess;
using System.Configuration;

namespace MyWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动服务时执行
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            FileStream fs = new FileStream(ConfigurationManager.AppSettings["LogFile"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(string.Format("Windows Service Start At {0} \n", DateTime.Now.ToString()));
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 停止服务时执行
        /// </summary>
        protected override void OnStop()
        {
            FileStream fs = new FileStream(ConfigurationManager.AppSettings["LogFile"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(string.Format("Windows Service Stop At {0} \n", DateTime.Now.ToString()));
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
