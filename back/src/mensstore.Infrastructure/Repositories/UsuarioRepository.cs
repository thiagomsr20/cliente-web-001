using mensstore.Core;
using mensstore.Core.Interfaces;
using mensstore.Infrastructure;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Xml.Linq;

namespace mensstore.Infrastructure;

public class UsuarioRepository : IUsuarioRepository
{
    public bool Delete(string name)
    {
        bool success = false;

        string query = $"DELETE FROM mensstore.usuario WHERE Name = '{name}'";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }

        return success;
    }

    public bool Register(Usuario usuario)
    {
        bool success = false;

        string query = $"INSERT INTO mensstore.usuario(Name, PasswordHash) VALUES('{usuario.Name}', '{usuario.PasswordHash}');";
        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }

        return success;
    }

    public bool Update(string name, Usuario newUserData)
    {
        bool success = false;

        string query = $"UPDATE mensstore.usuario SET Name = '{newUserData.Name}', PasswordHash = '{newUserData.PasswordHash}'" +
                        $" WHERE Name = '{name}';";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }
        return success;
    }

    public Usuario? GetByName(string name) => GetAll().FirstOrDefault(user => user.Name == name);

    public List<Usuario> GetAll()
    {
        List<Usuario> usuarios = new List<Usuario>();

        string query = "SELECT Name, PasswordHash FROM usuario";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);

            conc.Open();
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                var user = new Usuario();
                user.Name = reader[0].ToString() ?? string.Empty;
                user.PasswordHash = reader[1].ToString() ?? string.Empty;

                usuarios.Add(user);
            }
        }

        return usuarios;
    }
}
