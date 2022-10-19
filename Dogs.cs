using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jhoney_winform;

public partial class Dogs : Form
{
    public Dogs()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        textBox2.Text =  $"Name  |  Breed   {Environment.NewLine}";        
        string ServerName = "tcp:jhoney-sql-tutorial.database.windows.net,1433;Initial";
        string Database = "jhoney";
        string Username = "mowgli";
        string Pass = "m0wg1_the3_d0G";
        SqlConnection connection = new SqlConnection();

        connection.ConnectionString = $"Server={ServerName} Catalog={Database};Persist Security Info=False;User ID={Username};Password={Pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        SqlCommand command = new SqlCommand();

        var targetDogName = textBox1.Text;

        command.Connection = connection;
        command.CommandText = $"SELECT d1.Name, d1.Breed FROM DogFriend df JOIN Dog d1 ON d1.Id = df.FriendId JOIN Dog d2 ON d2.Id = df.DogId WHERE d2.Name = '{targetDogName}'";
        command.CommandType = CommandType.Text;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string friendName = (string)reader[0];
                string friendBreed = (string)reader[1];
                //MessageBox.Show($"~~~ friends {friendName} ~~~");
                textBox2.Text += $"{friendName} | {friendBreed}  {Environment.NewLine}";
            }

            reader.Close();
        }
        catch
        {
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        string ServerName = "tcp:jhoney-sql-tutorial.database.windows.net,1433;Initial";        
        string Database = "jhoney";
        string Username = "mowgli";
        string Pass = "m0wg1_the3_d0G";

        string connetionString;
        SqlConnection cnn;
        connetionString = $"Server={ServerName} Catalog={Database};Persist Security Info=False;User ID={Username};Password={Pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";        
        cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            Console.WriteLine("~~~ Connection Open  ! ~~~");
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }
        catch (Exception) { 
            Console.WriteLine("~~~ Login Failed, Information is Incorrect ~~~");
            MessageBox.Show("Login Failed, Information is Incorrect"); 
        }
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }
}
