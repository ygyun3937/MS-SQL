using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace _221107_MSSQL
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();

            MSSql_Open();
        }


        public void MSSql_Open()
        {
            string connStr = "SERVER=DESKTOP-29PU1UU;DATABASE=server_DB;UID=test2;PASSWORD=1;";
            conn = new SqlConnection(connStr);
            conn.ConnectionString = connStr;

            conn.Open();
            
           

        }

        public void MSSql_Insert(string strData1, string strData2)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            string commandText =  string.Format("insert into WPF_Test(name,age) values({0},{1})", strData1, strData2);

            cmd.CommandText = commandText;


            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sd.Fill(ds, "WPF_Test");

            conn.Close();
        }
        //open
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MSSql_Open();
        }

        //insert
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strData1;
            string strData2;
            strData1 = NameText.Text;
            strData2 = ageText.Text;


            MSSql_Insert(strData1, strData2);
        }

    }
}
