using Denis_Partner_Group.Domains;
using Denis_Partner_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Denis_Partner_Group.Repositories
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        private string StringConexao = "Data Source=36864133885; Initial Catalog= PARTNER_GROUP; user id=sa; password=S#nai@132";
        //private string StringConexao = "Data Source=36864133885; initial catalog= PARTNER_GROUP; integrated security=true";

        public void Cadastrar(PatrimonioDomain patrimonio)
        {
            string QueryInsert = @"INSERT INTO PATRIMONIO(NOME,MARCAID,DESCRICAO) VALUES (@NOME,@MARCAID,@DESCRICAO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", patrimonio.Nome);
                    cmd.Parameters.AddWithValue("@MARCAID", patrimonio.MarcaId);
                    cmd.Parameters.AddWithValue("@DESCRICAO", patrimonio.Descricao);

                    cmd.ExecuteNonQuery();
                }
            }

        
        }

        public List<PatrimonioDomain> ListarTodos()
        {
            string QuerySelect = "SELECT NOME,MARCAID,DESCRICAO,NUMERO_TOMBO FROM PATRIMONIO;";

            List<PatrimonioDomain> ListaPatrimonio = new List<PatrimonioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        PatrimonioDomain patrimonio = new PatrimonioDomain
                        {                       
                            Nome = sdr["NOME"].ToString(),
                            MarcaId = Convert.ToInt32(sdr["MARCAID"]),
                            Descricao = sdr["DESCRICAO"].ToString(),
                            NumeroTombo = Convert.ToInt32(sdr["NUMERO_TOMBO"])
                        };

                        ListaPatrimonio.Add(patrimonio);
                    }

                    return ListaPatrimonio;
                }
            }
            
            
        }


    }
}
