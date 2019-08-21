﻿using Denis_Partner_Group.Domains;
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
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog= PARTNER_GROUP_DENIS; user id=sa; password=132";
        //private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= PARTNER_GROUP_DENIS; integrated security=true";

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
            string QuerySelect = "SELECT NOME, MARCAID, DESCRICAO FROM PATRIMONIO";

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
                            MarcaId = Convert.ToInt32(sdr["id"]),
                            Descricao = sdr["DESCRICAO"].ToString()
                        };

                        ListaPatrimonio.Add(patrimonio);
                    }

                    return ListaPatrimonio;
                }
            }
            
            
        }


    }
}
