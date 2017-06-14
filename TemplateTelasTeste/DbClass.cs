using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace NavKids {
    public static class DbClass {
        private static string path = "Data Source = DataBase.db";

        public static int getId(string usuario) {
            int ret = -1;
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT id FROM Usuarios WHERE usuario = @usuario", conn)) {
                    comm.Parameters.AddWithValue("@usuario", usuario);
                    conn.Open();
                    ret = Convert.ToInt32(comm.ExecuteScalar());
                }
            }
            return ret;
        }

        public static string getPass(int id) {
            string pass = null;
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT senha FROM usuario WHERE id = @Id", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    pass = Convert.ToString(comm.ExecuteScalar());
                }
            }
            return pass;
        }

        public static bool VerifyUser(string usuario, string senha) {
            bool ret = false;
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT 'True' FROM usuarios WHERE usuario = @usuario AND senha = @senha", conn)) {
                    comm.Parameters.AddWithValue("@usuario", usuario);
                    comm.Parameters.AddWithValue("@senha", senha);
                    conn.Open();
                    ret = Convert.ToBoolean(comm.ExecuteScalar());
                    //MessageBox.Show("" + ret.ToString());
                }
                return ret;
            }
        }

        public static string[] getUsers() {
            List<string> arrayDi = new List<string>();
            string[] ret = new string[] { "Sem Dados" };
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT [usuario] FROM [usuarios]", conn)) {
                    conn.Open();
                    using (SQLiteDataReader readerr = comm.ExecuteReader()) {
                        while (readerr.Read()) {
                            arrayDi.Add(readerr["usuario"].ToString());
                        }
                    }
                }
            }
            ret = arrayDi.ToArray();
            return ret;
        }

        public static bool setUser(string usuario, string senha, string admin) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("INSERT INTO [Usuarios](usuario,senha,NivelU) VALUES (@usuario,@senha,@admin)", conn)) {
                    comm.Parameters.AddWithValue("@admin",admin);
                    comm.Parameters.AddWithValue("@senha",senha);
                    comm.Parameters.AddWithValue("@usuario",usuario);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        MessageBox.Show("Usuario Criado com sucesso!!");
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool deletUser(string usuario) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("DELETE FROM [usuarios] WHERE usuario = @usuario", conn)) {
                    comm.Parameters.AddWithValue("@usuario", usuario);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        MessageBox.Show("Usuario Excluido com Sucesso!!");
                        return true;
                    }
                    else {
                        MessageBox.Show("Usuario não existente ou não encontrado!! ");
                        return false;
                    }

                }
            }
        }

        public static DateTime GetNetworkTime() {
            //Servidor nacional para melhor latência
            const string ntpServer = "a.ntp.br";

            // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
            var ntpData = new byte[48];

            //Indicador de Leap (ver RFC), Versão e Modo
            ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //123 é a porta padrão do NTP
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP usa UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Caso NTP esteja bloqueado, ao menos nao trava o app
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset para chegar no campo "Transmit Timestamp" (que é
            //o do momento da saída do servidor, em formato 64-bit timestamp
            const byte serverReplyTime = 40;

            //Pegando os segundos
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //e a fração de segundos
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Passando de big-endian pra little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //Tempo em **UTC**
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x) {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static void getday(string usuario) {
            string[] ret = new string[] { };
            DateTime dataservidor = GetNetworkTime();
            //MessageBox.Show("" + (int)dataservidor.DayOfWeek);
            string dia = DateTime.Now.DayOfWeek.ToString();
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Config WHERE id = @id", conn)) {
                    comm.Parameters.AddWithValue("@id", getId(usuario));
                    conn.Open();
                    using (SQLiteDataReader readerr = comm.ExecuteReader()) {
                        while (readerr.Read()) {
                            ret = new string[] {
                            readerr["Seg"].ToString(),
                            readerr["Ter"].ToString(),
                            readerr["Qua"].ToString(),
                            readerr["Qui"].ToString(),
                            readerr["Sex"].ToString(),
                            readerr["Sab"].ToString(),
                            readerr["Dom"].ToString(),
                            readerr["NiveQ"].ToString(),
                            readerr["usado"].ToString(),
                            };
                        }
                    }
                }
            }
            if (ret[0] == "True" && dataservidor.DayOfWeek.ToString() == "Monday" ||
                    ret[1] == "True" && dataservidor.DayOfWeek.ToString() == "Tuesday" ||
                    ret[2] == "True" && dataservidor.DayOfWeek.ToString() == "Wednesday" ||
                    ret[3] == "True" && dataservidor.DayOfWeek.ToString() == "Thursday" ||
                    ret[4] == "True" && dataservidor.DayOfWeek.ToString() == "Friday" ||
                    ret[5] == "True" && dataservidor.DayOfWeek.ToString() == "Saturday" ||
                    ret[6] == "True" && dataservidor.DayOfWeek.ToString() == "Sunday") 
            { }
            else {
                if (dataservidor.DayOfWeek.ToString() == "Monday") {
                    MessageBox.Show("Hoje é Segunda-Feira, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Tuesday") {
                    MessageBox.Show("Hoje é Terça-Feira, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Wednesday") {
                    MessageBox.Show("Hoje é Quarta-Feira, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Thursday") {
                    MessageBox.Show("Hoje é Quinta-Feira, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Friday") {
                    MessageBox.Show("Hoje é Sexta-Feira, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Saturday") {
                    MessageBox.Show("Hoje é Sábado, você não pode navegar hoje!");
                    Application.Restart();
                }
                if (dataservidor.DayOfWeek.ToString() == "Sunday") {
                    MessageBox.Show("Hoje é Domingo, você não pode navegar hoje!");
                    Application.Restart();
                }
            }
        }

        public static string[] getConfig(int id) {
            string[] ret = new string[] { };
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using(SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Config WHERE Id = " + id, conn)) {
                    conn.Open();
                    using (SQLiteDataReader readerr = comm.ExecuteReader()) {
                        while (readerr.Read()) {
                            ret = new string[] {
                            readerr["Seg"].ToString(),
                            readerr["Ter"].ToString(),
                            readerr["Qua"].ToString(),
                            readerr["Qui"].ToString(),
                            readerr["Sex"].ToString(),
                            readerr["Sab"].ToString(),
                            readerr["Dom"].ToString(),
                            readerr["NiveQ"].ToString(),
                            readerr["tempo"].ToString(),
                            readerr["TempUsado"].ToString()
                            };
                        }
                    }
                }

            }
            if (ret.Count() == 0) {
                return new string[] { "sem Info" };
            }
            return ret;
        }

        public static bool setSite(int id, string site) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("INSERT INTO [Sites](Id,NomeSi) VALUES (@Id,@NomeSi)", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@NomeSi", site);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static bool setDia(int id) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("update [Config] set [Usado] = datetime('now') WHERE Id = @Id", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static string getday(int id) {
            string ret = null;
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT strftime('%d/%m/%Y %H:%M:%S', usado) as usado FROM Config WHERE Id = @Id",conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using (SQLiteDataReader readerr = comm.ExecuteReader()) {
                        while (readerr.Read()) {
                            ret = readerr["usado"].ToString();
                        }
                    }
                }
            }
            if (ret != null) {
                return ret;
            }
            return "sem dados";
        }

        public static string[] getSites(int id) {
            List<string> arrayDi = new List<string>();
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT[NomeSi] FROM[Sites] WHERE Id = @Id", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using(SQLiteDataReader readerr = comm.ExecuteReader()) {
                        while (readerr.Read()) {
                            arrayDi.Add(readerr["NomeSi"].ToString());
                        }
                    }
                }
            }
            if (arrayDi.ToArray().Count() == 0) {
                return new string[] { "sem dados" };
            }
            return arrayDi.ToArray();
        }

        public static bool deletSite(int id, string site) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("DELETE FROM Sites WHERE Id = @Id AND NomeSi = @Site",conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Site", site);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool setConfig(int id, string[] configs) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("UPDATE [Config] SET Seg = @Seg, Ter = @Ter, Qua = @Qua, Qui = @Qui, Sex = @Sex, " +
                        "Sab = @Sab, Dom = @Dom, NiveQ = @NiveQ, tempo = @tempo WHERE Id = @Id ", conn)) {

                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Seg", configs[0]);
                    comm.Parameters.AddWithValue("@Ter", configs[1]);
                    comm.Parameters.AddWithValue("@Qua", configs[2]);
                    comm.Parameters.AddWithValue("@Qui", configs[3]);
                    comm.Parameters.AddWithValue("@Sex", configs[4]);
                    comm.Parameters.AddWithValue("@Sab", configs[5]);
                    comm.Parameters.AddWithValue("@Dom", configs[6]);
                    comm.Parameters.AddWithValue("@NiveQ", configs[7]);
                    comm.Parameters.AddWithValue("@tempo", configs[8]);

                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        MessageBox.Show("Configuração salva com sucesso!!");
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool updatePass(int id, string senha) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("UPDATE [Usuarios] SET senha = @senha WHERE Id = @Id ", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@senha", senha);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        MessageBox.Show("Senha alterada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    return false;
                }
            }
        }


        public static bool setTempUsed(int id) {
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("update [Config] set [TempUsado] = 0 WHERE Id = @Id",conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    if (comm.ExecuteNonQuery() != 0) {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool setTempUsed(int id, int temp) {
            try {
                using (SQLiteConnection conn = new SQLiteConnection(path)) {
                    using (SQLiteCommand comm = new SQLiteCommand("update [Config] set [TempUsado] = @temp WHERE Id = @Id", conn)) {
                        comm.Parameters.AddWithValue("@Id", id);
                        comm.Parameters.AddWithValue("@temp", temp);
                        conn.Open();
                        if (comm.ExecuteNonQuery() != 0) {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex);
                return false;
            }
        }

        public static int getOnlyNum(string str) {
            Regex re = new Regex("[0-9]");
            StringBuilder s = new StringBuilder();

            foreach (Match m in re.Matches(str)) {
                s.Append(m.Value);
            }

            //MessageBox.Show(s.ToString());
            return int.Parse(s.ToString());
        }

        public static bool getNivelU(int id){
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT [NivelU] FROM [usuarios] WHERE [id] = @id", conn)) {
                    comm.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    return bool.Parse(Convert.ToString(comm.ExecuteScalar()));
                }
            }
        }

        public static string[] getQuiz(string nivel) {
            string[] ret = new string[] { };
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Questoes WHERE nivel = @nivel ORDER BY Random() LIMIT 1",conn)) {
                    comm.Parameters.AddWithValue("@nivel", nivel);
                    conn.Open();
                    using (SQLiteDataReader reader = comm.ExecuteReader()) {
                        while (reader.Read()) {
                            ret = new string[] {
                                reader["pergunta"].ToString(),
                                reader["posivel1"].ToString(),
                                reader["posivel2"].ToString(),
                                reader["resposta"].ToString()
                            };
                        }
                    }
                }
            }
            return ret;
        }
    }

}
