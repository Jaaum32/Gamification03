using System.Data;
using MySql.Data.MySqlClient;


public class Erick
{
    public static void Main()
    {
        Console.WriteLine("Penis");

        DataSet mDataSet = new DataSet();

        MySqlConnection mySqlConnection = new MySqlConnection("Persist Security Info=False;server=localhost;database=gamefication;uid=root;pwd=260405");
        
        try{
            //abre a conexao
            mySqlConnection.Open();
        }
        catch(System.Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }

 

        //verificva se a conexão esta aberta

        if (mySqlConnection.State == ConnectionState.Open)

        {

            //cria um adapter usando a instrução SQL para acessar a tabela Clientes

            MySqlDataAdapter mAdapter = new  MySqlDataAdapter("SELECT * FROM Pedido", mySqlConnection);

            Console.WriteLine(mAdapter.ToString());

        }
    }
}