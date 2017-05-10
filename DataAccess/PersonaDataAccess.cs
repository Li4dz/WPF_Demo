using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess
{
    public class PersonaDataAccess
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cn_BDPrueba"].ConnectionString;

        public int RegistarPersona(Persona oPersona)
        {
            int resultado = 0;
            SqlCommand oSqlCommand = new SqlCommand();
            oSqlCommand.CommandText = "[Maestro].[Usp_Ins_Persona]";
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.Parameters.AddWithValue("@Nombre", oPersona.Nombre);
            oSqlCommand.Parameters.AddWithValue("@Apellido", oPersona.Apellido);
            oSqlCommand.Parameters.AddWithValue("@Sexo", oPersona.Sexo.ValorSexo);
            oSqlCommand.Parameters.AddWithValue("@FechaNacimiento", oPersona.FechaNacimiento);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                oSqlCommand.Connection = connection;
                connection.Open();
                resultado = oSqlCommand.ExecuteNonQuery();
                connection.Close();
            }

            return resultado;
        }

        public ListaPersona ListarPersona()
        {
            SqlCommand oSqlcommand = new SqlCommand();
            ListaPersona oListaPersona = new ListaPersona();
            Persona oPersona = null;
            oSqlcommand.CommandText = "[Maestro].[Usp_Sel_Persona]";
            oSqlcommand.CommandType = CommandType.StoredProcedure;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                oSqlcommand.Connection = connection;
                connection.Open();

                using (SqlDataReader reader = oSqlcommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        oPersona = new Persona();
                        oPersona.Nombre = reader[0].ToString();
                        oPersona.Apellido = reader[1].ToString();
                        oPersona.Sexo = new Sexo() { ValorSexo = Convert.ToBoolean(reader[2]), SexoNombre = Convert.ToBoolean(reader[2]) ? "MALE" : "FEMALE"};
                        oPersona.FechaNacimiento = Convert.ToDateTime(reader[3]);
                        oListaPersona.Add(oPersona);
                    }
                }
            }
            return oListaPersona;
        }
    }
}
