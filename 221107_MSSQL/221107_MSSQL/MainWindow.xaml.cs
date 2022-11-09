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
        public MainWindow()
        {
            InitializeComponent();

            MSSql_Open();
        }


        public void MSSql_Open()
        {
            string connStr = "SERVER=DESKTOP-29PU1UU;DATABASE=server_DB;UID=test2;PASSWORD=1;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.ConnectionString = connStr;

            SqlCommand cmd = new SqlCommand("_getData", conn);
            SqlParameter name = new SqlParameter("@name", SqlDbType.NChar);

            name.Value = "test";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(name);

            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int dt = cmd.ExecuteNonQuery();
            sda.Fill(ds);

        }





    }
}
