using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;  
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_Alunos
{
    class sisDBADM
    {
        private const string _strCon = @"Data Source=NOTE-DELL\SQLEXPRESS;Initial Catalog=CRUD_ALUNOS;User ID=sa;Password=h5g46410";
        private string vsql = "";
        SqlConnection objCon = null;

        #region "Métodos de conexão com o Banco"
        private bool conectar()
        {
            objCon = new SqlConnection(_strCon);
            try
            {
                objCon.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }

        private bool desconectar()
        {
            if (objCon.State != ConnectionState.Closed)
            {
                objCon.Close();
                objCon.Dispose();
                return true;
            }
            else
            {
                objCon.Dispose();
                return false;
            }


        }
        #endregion

        #region "Métodos de execução de SQL"
        
        #region "Método Insert" 
        public bool Insert(ArrayList p_arrInsert)
        {
            vsql = "INSERT INTO CRUD_ALUNOS ([NOME], [IDADE], [ENDERECO], [TELEFONE], [EMAIL], [CPF], [CIDADE], [UF], [CEP], [NOME_PAI], [NOME_MAE])" +
                "VALUES(@NOME, @IDADE, @ENDERECO, @TELEFONE, @EMAIL, @CPF, @CIDADE, @UF, @CEP, @NOME_PAI, @NOME_MAE)";
            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@nome", p_arrInsert[0]));
                    objcmd.Parameters.Add(new SqlParameter("@idade", p_arrInsert[1]));
                    objcmd.Parameters.Add(new SqlParameter("@endereco", p_arrInsert[2]));
                    objcmd.Parameters.Add(new SqlParameter("@telefone", p_arrInsert[3]));
                    objcmd.Parameters.Add(new SqlParameter("@email", p_arrInsert[4]));
                    objcmd.Parameters.Add(new SqlParameter("@cpf", p_arrInsert[5]));
                    objcmd.Parameters.Add(new SqlParameter("@cidade", p_arrInsert[6]));
                    objcmd.Parameters.Add(new SqlParameter("@uf", p_arrInsert[7]));
                    objcmd.Parameters.Add(new SqlParameter("@cep", p_arrInsert[8]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_pai", p_arrInsert[9]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_mae", p_arrInsert[10]));

                    objcmd.ExecuteNonQuery();

                    return true;            
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return false;
            }

           
        }
        #endregion

        #region "Método Update"
        public bool Update(ArrayList p_arrUpdate)
        {
            vsql = "UPDATE CRUD_ALUNOS SET [NOME] = @NOME, [IDADE] = @IDADE, [ENDERECO] = @ENDERECO, [TELEFONE] = @TELEFONE, [EMAIL] = @EMAIL, [CPF] = @CPF," +
            "[CIDADE] = @CIDADE, [UF] = @UF, [CEP] = @CEP, [NOME_PAI] = @NOME_PAI, [NOME_MAE] = @NOME_MAE" + 
            
            " WHERE ID_ALUNO = @ID_ALUNO";

            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@id_aluno", p_arrUpdate[0]));
                    objcmd.Parameters.Add(new SqlParameter("@nome", p_arrUpdate[1]));
                    objcmd.Parameters.Add(new SqlParameter("@idade", p_arrUpdate[2]));
                    objcmd.Parameters.Add(new SqlParameter("@endereco", p_arrUpdate[3]));
                    objcmd.Parameters.Add(new SqlParameter("@telefone", p_arrUpdate[4]));
                    objcmd.Parameters.Add(new SqlParameter("@email", p_arrUpdate[5]));
                    objcmd.Parameters.Add(new SqlParameter("@cpf", p_arrUpdate[6]));
                    objcmd.Parameters.Add(new SqlParameter("@cidade", p_arrUpdate[7]));
                    objcmd.Parameters.Add(new SqlParameter("@uf", p_arrUpdate[8]));
                    objcmd.Parameters.Add(new SqlParameter("@cep", p_arrUpdate[9]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_pai", p_arrUpdate[10]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_mae", p_arrUpdate[11]));

                    objcmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region "Método Delete"
        public bool Delete()
        {
            return false;
        }
        #endregion
        #endregion

        #region "Métodos de listagem de grid e pesquisar"
        public DataTable ListaGrid()
        {
            return null;
        }

        public DataTable Pesquisar()
        {
            return null;
        }
        #endregion
    }
}
