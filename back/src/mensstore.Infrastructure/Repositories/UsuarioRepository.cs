using mensstore.Core;
using mensstore.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace mensstore.Infrastructure;

public class UsuarioRepository : IUsuarioRepository
{
    public bool Delete(string name)
    {
        bool success = false;

        string query = "DELETE FROM mensstore.usuario WHERE Name = @Name;";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Name", name);

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
        string query = "INSERT INTO mensstore.usuario(Name, PasswordHash) VALUES(@Name, @PasswordHash);";
        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Name", usuario.Name);
            comm.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);

            conc.Open();
            int affectedRow = comm.ExecuteNonQuery();

            if (affectedRow != 0)
                success = true;
        }

        return success;
    }
    public bool Update(string name, Usuario newUserData)
    {
        bool success = false;

        string query = "UPDATE mensstore.usuario SET Name = @Name, PasswordHash = @PasswordHash WHERE Name = @Name;";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Name", newUserData.Name);
            comm.Parameters.AddWithValue("@PasswordHash", newUserData.PasswordHash);

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
        string query = "SELECT * FROM usuario";
        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            try
            {
                conc.Open();
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    var user = new Usuario()
                    {
                        Name = reader.GetString("Name"),
                        PasswordHash = reader.GetString("PasswordHash")
                    };
                    usuarios.Add(user);
                }
            }
            catch (MySqlException ex)
            {
                // Log the exception details here or handle them accordingly
                Console.WriteLine("MySQL error: " + ex.Message);
            }
        }

        return usuarios;
    }
}
