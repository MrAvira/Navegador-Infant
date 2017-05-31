using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

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
            catch (Exception) {
                MessageBox.Show( "Usuário já existe!","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        public static DateTime GetNetworkTime()
        {
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
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static string[] getday(string usuario){
            //TODO SELECT * FROM Config WHERE Id = " + getId(usuario);
            string[] ret = new string[] { };
            try{
                cmd = new SqlCommand("SELECT * FROM Config WHERE Id = " + getId(usuario), cn);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()){
                    ret = new string[] {
                        reader["Seg"].ToString(),
                        reader["Ter"].ToString(),
                        reader["Qua"].ToString(),
                        reader["Qui"].ToString(),
                        reader["Sex"].ToString(),
                        reader["Sab"].ToString(),
                        reader["Dom"].ToString(),
                        reader["NiveQ"].ToString(),
                        reader["usado"].ToString(),
                    };
                }
                cn.Close();
                if (ret.Count() == 0){
                    return new string[] { "sem Info" };
                }

                DateTime dataservidor = GetNetworkTime();
                string dia = DateTime.Now.DayOfWeek.ToString();
                //MessageBox.Show(ret[0]);
                //MessageBox.Show(ret[1]);
                //MessageBox.Show(dataservidor.DayOfWeek.ToString());

                if( ret[0] == "True" && dataservidor.DayOfWeek.ToString() == "Monday" ||
                    ret[1] == "True" && dataservidor.DayOfWeek.ToString() == "Tuesday" ||
                    ret[2] == "True" && dataservidor.DayOfWeek.ToString() == "Wednesday" ||
                    ret[3] == "True" && dataservidor.DayOfWeek.ToString() == "Thursday" ||
                    ret[4] == "True" && dataservidor.DayOfWeek.ToString() == "Friday" ||
                    ret[5] == "True" && dataservidor.DayOfWeek.ToString() == "Saturday" ||
                    ret[6] == "True" && dataservidor.DayOfWeek.ToString() == "Sunday"){
                    

                }
                else{
                    if (dataservidor.DayOfWeek.ToString() == "Monday"){ 
                    MessageBox.Show("Hoje é Segunda-Feira, você não pode navegar hoje!");
                    Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Tuesday"){
                        MessageBox.Show("Hoje é Terça-Feira, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Wednesday"){
                        MessageBox.Show("Hoje é Quarta-Feira, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Thursday"){
                        MessageBox.Show("Hoje é Quinta-Feira, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Friday"){
                        MessageBox.Show("Hoje é Sexta-Feira, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Saturday"){
                        MessageBox.Show("Hoje é Sábado, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    if (dataservidor.DayOfWeek.ToString() == "Sunday"){
                        MessageBox.Show("Hoje é Domingo, você não pode navegar hoje!");
                        Application.Restart();
                    }
                    
                }

                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                cn.Close();
                return new string[] { "erro" };
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
                        reader["tempo"].ToString(),
                        reader["TempUsado"].ToString()
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

        public static bool setDia(int id){
            try{
                cmd = new SqlCommand("update [Config] set [Usado] = getdate() WHERE Id = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex){
                MessageBox.Show("" + ex);
                cn.Close();
                return false;
            }
        }

        public static string getday(int id){
            try{
                string ret = null;
                cmd = new SqlCommand("SELECT [Usado] FROM [Config] WHERE Id = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()){
                    ret = reader["Usado"].ToString();
                }
                if(ret != null) {
                    cn.Close();
                    return ret;
                }
                cn.Close();
                    return "sem dados";
            }
            catch (Exception ex){
                MessageBox.Show("" + ex);
                cn.Close();
                return "sem dados";
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
                    "NiveQ = @NiveQ, " +
                    "tempo = @tempo " +
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
                cmd.Parameters.AddWithValue("@tempo", configs[8]);
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

        public static bool setTempUsed(int id) {
            //Override: seta 0 se não for colocado o parametro int
            try {
                cmd = new SqlCommand("update [Config] set [TempUsado] = 0 WHERE Id = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
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

        public static bool setTempUsed(int id, int temp) {
            //Override: seta um valor se for colocado o parametro int
            try {
                cmd = new SqlCommand("update [Config] set [TempUsado] = @temp WHERE Id = @Id", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@temp", temp);
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

        public static int getOnlyNum(string str) {
            Regex re = new Regex("[0-9]");
            StringBuilder s = new StringBuilder();

            foreach (Match m in re.Matches(str)) {
                s.Append(m.Value);
            }

            //MessageBox.Show(s.ToString());
            return int.Parse(s.ToString());
        }
    }
}
