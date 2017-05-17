using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTelasTeste {
    public static class DbClass {
        //private static SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        private static SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Navegador_flavioVersion\TemplateTelasTeste\Database1.mdf;Integrated Security=True;Connect Timeout=30");
        private static SqlCommand cmd;
        private static SqlDataReader reader;
        
        public static int getId(string usuario) {
            int num;
            try {
                cmd = new SqlCommand("SELECT [Id] FROM [dbo].[usuarios] WHERE [usuario] = @usuario", cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    num = int.Parse(reader["Id"].ToString());
                    cn.Close();
                    return num;
                }
                cn.Close();
                return -1;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return -1;
            }
        }

        public static string getPass(int id) {
            string pass;
            try {
                cmd = new SqlCommand("SELECT [senha] FROM [usuarios] WHERE [Id] = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    pass = reader["senha"].ToString();
                    cn.Close();
                    return pass;
                }
                cn.Close();
                return "Erro";
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return "Erro";
            }
        }

        public static bool VerifyUser(string usuario, string senha) {
            try {
                cmd = new SqlCommand("SELECT [Id] FROM [dbo].[usuarios] WHERE [usuario] = @usuario AND [senha] = @senha", cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    cn.Close();
                    return true;
                }
                cn.Close();
                return false;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static string[] getUsers() {
            List<string> arrayDi = new List<string>();
            string[] ret = new string[]{};
            try {
                cmd = new SqlCommand("SELECT [usuario] FROM [usuarios]", cn);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    arrayDi.Add(reader["usuario"].ToString());
                }
                cn.Close();
                ret = arrayDi.ToArray();
                if (ret.Count() == 0) {
                    return new string[] { "sem dados" };
                }
                return ret;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return ret = new string[]{"sem dados"};
            }
        }

        public static bool setUser(string usuario, string senha) {
            try {
                cmd = new SqlCommand("INSERT INTO [Usuarios](usuario,senha) VALUES (@usuario,@senha)", cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                cn.Open();
                if(cmd.ExecuteNonQuery() != 0) {
                    MessageBox.Show("Usuario Criado com sucesso!!");
                }
                cn.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static bool deletUser(string usuario) {
            try {
                cmd = new SqlCommand("DELETE FROM [usuarios] WHERE usuario = @usuario", cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cn.Open();
                if (cmd.ExecuteNonQuery() != 0) {
                    MessageBox.Show("Usuario Excluido com Sucesso!!");
                    cn.Close();
                    return true;
                }
                else {
                    MessageBox.Show("Usuario não existente ou não encontrado!! ");
                    cn.Close();
                    return false;
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static string[] getConfig(string usuario) {
            //TODO SELECT * FROM Config WHERE Id = " + getId(usuario);
            string[] ret = new string[]{};
            try {
                cmd = new SqlCommand("SELECT * FROM Config WHERE Id = " + getId(usuario), cn);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    ret = new string[] {
                        reader["Seg"].ToString(),
                        reader["Ter"].ToString(),
                        reader["Qua"].ToString(),
                        reader["Qui"].ToString(),
                        reader["Sex"].ToString(),
                        reader["Sab"].ToString(),
                        reader["Dom"].ToString(),
                        reader["NiveQ"].ToString(),
                    };
                }
                cn.Close();
                if (ret.Count() == 0) {
                    return new string[] { "sem Info" };
                }
                return ret;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return new string[] { "erro" };
            }
        }

        public static bool setSite(int id, string site) {
            try {
                cmd = new SqlCommand("INSERT INTO [Sites](Id,NomeSi) VALUES (@Id,@NomeSi)", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@NomeSi", site);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static string[] getSites(int id) {
            List<string> arrayDi = new List<string>();
            string[] ret = new string[] { };
            try {
                cmd = new SqlCommand("SELECT [NomeSi] FROM [Sites] WHERE Id = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    arrayDi.Add(reader["NomeSi"].ToString());
                }
                cn.Close();
                ret = arrayDi.ToArray();
                if (ret.Count() == 0) {
                    return new string[] { "sem dados" };
                }
                return ret;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return ret = new string[] { "sem dados" };
            }
        }

        public static bool deletSite(int id, string site) {
            try {
                cmd = new SqlCommand("DELETE FROM [Sites] WHERE Id = @Id AND NomeSi = @Site", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Site", site);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static bool setConfig(int id, string[] configs) {
            try {
                cmd = new SqlCommand("UPDATE [Config] SET " +
                    "Seg = @Seg, " +
                    "Ter = @Ter, " +
                    "Qua = @Qua, " +
                    "Qui = @Qui, " +
                    "Sex = @Sex, " +
                    "Sab = @Sab, " +
                    "Dom = @Dom, " +
                    "NiveQ = @NiveQ " +
                    "WHERE Id = @Id ", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Seg", configs[0]);
                cmd.Parameters.AddWithValue("@Ter", configs[1]);
                cmd.Parameters.AddWithValue("@Qua", configs[2]);
                cmd.Parameters.AddWithValue("@Qui", configs[3]);
                cmd.Parameters.AddWithValue("@Sex", configs[4]);
                cmd.Parameters.AddWithValue("@Sab", configs[5]);
                cmd.Parameters.AddWithValue("@Dom", configs[6]);
                cmd.Parameters.AddWithValue("@NiveQ", configs[7]);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Configuração Salva");
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static bool updatePass(int id, string senhan) {
            try {
                cmd = new SqlCommand("UPDATE [Usuarios] SET senha = @senha WHERE Id = @Id ", cn);
                cmd.Parameters.AddWithValue("@senha", senhan);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Senha alterada com sucesso!", "Sucesso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }
    }
}
