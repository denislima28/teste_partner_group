using Denis_Partner_Group.Domains;
using Denis_Partner_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Denis_Partner_Group.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private string StringConexao = "Data Source=36864133885; Initial Catalog= PARTNER_GROUP; user id=sa; password=S#nai@132";
        //private string StringConexao = "Data Source=36864133885; initial catalog= PARTNER_GROUP; integrated security=true";

        public void Cadastrar(MarcaDomain marca)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO MARCA(NOME) VALUES(@NOME)";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", marca.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<MarcaDomain> ListarTodos()
        {
            string QuerySelect = "SELECT * FROM MARCA";

            List<MarcaDomain> ListaMarca = new List<MarcaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        MarcaDomain marca = new MarcaDomain
                        {
                            MarcaId = Convert.ToInt32(sdr["MARCAID"]),
                            Nome = sdr["NOME"].ToString()
                        };

                        ListaMarca.Add(marca);
                    }

                    return ListaMarca;
                }
            }    

        }

    }

}