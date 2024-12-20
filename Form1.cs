using MySql.Data.MySqlClient;
using static user.Connector;

namespace user
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from `user`";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            try
            {
                conn.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string firstname = dr.GetString(1);
                    string lastname = dr.GetString(2);
                    string password = dr.GetString(3);
                    DateTime createdtime = DateTime.MinValue;
                    DateTime updatedtime = DateTime.MinValue;

                    // Handle conversion for createdtime
                    if (!dr.IsDBNull(4))
                    {
                        createdtime = dr.GetDateTime(4);
                    }

                    // Handle conversion for updatedtime
                    if (!dr.IsDBNull(5))
                    {
                        updatedtime = dr.GetDateTime(5);
                    }

                    listBox1.Items.Add($"A felhasználó keresztneve: {firstname} vezetékneve: {lastname} jelszava: {password} készült: {createdtime} frissítve: {updatedtime}");
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Connection.Close();
            }
        }
    }
}