using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Alunos
{
    #region "Classe" 
    public partial class frm_Crud : Form
    {
        public frm_Crud()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;
            lbDateTime.Text = "Data: "+ dataHora.ToLongDateString() + " Hora: " + dataHora.ToLongTimeString();
        }

        private void frm_Crud_Load(object sender, EventArgs e)
        {
            timer1_Tick(e, e);

            sisDBADM test = new sisDBADM();
            /*  Teste da conexão
            if (test.conectar())
               {
                   MessageBox.Show("Conectou");
               }
               else
               {
                   MessageBox.Show("Não Conectou");
               } */
        }


        #region "btnSair"
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
                
        #region "btnCadastrar"
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            ArrayList arr = new ArrayList();
            /* ([NOME], [IDADE], [ENDERECO], [TELEFONE], [EMAIL], [CPF], [CIDADE], [UF], [CEP], [NOME_PAI], [NOME_MAE]) */
            arr.Add("Hugo Emiliano Almeida de Ávila");
            arr.Add(38);
            arr.Add("Av. 25 de Dezembro, 455");
            arr.Add("(34) 98806-7879");
            arr.Add("hugoemilianoavila@gmail.com");
            arr.Add("12346678900");
            arr.Add("Ituiutaba");
            arr.Add("MG");
            arr.Add("38307014");
            arr.Add("José Carlos");
            arr.Add("Cleonice");

            if (obj.Insert(arr))
            {
                MessageBox.Show("Aluno cadastrado com sucesso!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ocorrido!!! Aluno não cadastrado!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "btnEditar"
        private void btnEditar_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            ArrayList arr = new ArrayList();
            /* ([NOME], [IDADE], [ENDERECO], [TELEFONE], [EMAIL], [CPF], [CIDADE], [UF], [CEP], [NOME_PAI], [NOME_MAE]) */

            arr.Add(18);
            arr.Add("Tiana");
            arr.Add(47);
            arr.Add("Av. Boiadeiro, 455");
            arr.Add("(34) 0006-1234");
            arr.Add("tiao@gmail.com");
            arr.Add("32146699800");
            arr.Add("Gurinhatã");
            arr.Add("MG");
            arr.Add("38300000");
            arr.Add("Bastião");
            arr.Add("Bastiana");

            if (obj.Update(arr))
            {
                MessageBox.Show("Aluno atualizado com Sucesso!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ocorrido!!! Dados do aluno não atualizado!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnExcluir"
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            int codAluno = 13;

            if (obj.Delete(codAluno))
            {
                MessageBox.Show("Aluno apagado com sucesso!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ocorrido!!! Aluno não apagado!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            dgEdit.DataSource = obj.ListaGrid();            
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            dgExcluir.DataSource = obj.ListaGrid();

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            string sql;


            if (rbNome.Checked)
            {
                sql = "SELECT [NOME] as Nome, [IDADE] as Idade, [ENDERECO]as Endereço, [TELEFONE] as Fone, [EMAIL] as Email FROM CRUD_ALUNOS WHERE NOME LIKE @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, "%"+tbPesquisa.Text+ "%");
            }
            else
            {
                sql = "SELECT [NOME] as Nome, [IDADE] as Idade, [ENDERECO]as Endereço, [TELEFONE] as Fone, [EMAIL] as Email FROM CRUD_ALUNOS WHERE ID_ALUNO = @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, tbPesquisa.Text);
            }
        }
    }
#endregion

}


//#region "Eemplos de Teste no banco - Update"
//        public void TestDB()
//        {
//            sisDBADM obj = new sisDBADM();

//            ArrayList arr = new ArrayList();
//            /* ([NOME], [IDADE], [ENDERECO], [TELEFONE], [EMAIL], [CPF], [CIDADE], [UF], [CEP], [NOME_PAI], [NOME_MAE]) */

//arr.Add(18);
//            arr.Add("Tiana");
//            arr.Add(47);
//            arr.Add("Av. Boiadeiro, 455");
//            arr.Add("(34) 0006-1234");
//            arr.Add("tiao@gmail.com");
//            arr.Add("32146699800");
//            arr.Add("Gurinhatã");
//            arr.Add("MG");
//            arr.Add("38300000");            
//            arr.Add("Bastião");
//            arr.Add("Bastiana");

//            if (obj.Update(arr))
//            {
//                MessageBox.Show("Aluno atualizado com Sucesso!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Erro ocorrido!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//        #endregion

//

//#region "Teste no banco - Delete"
//public void TestDB()
//{
//    sisDBADM obj = new sisDBADM();

//    int codAluno = 14;

//    if (obj.Delete(codAluno))
//    {
//        MessageBox.Show("Aluno apagado com sucesso!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//    else
//    {
//        MessageBox.Show("Erro ocorrido!!! Aluno não apagado!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}
//#endregion