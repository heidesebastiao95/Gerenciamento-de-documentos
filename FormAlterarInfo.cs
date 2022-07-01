using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace exercicio3ConexaoBD
{
    public partial class FormAlterarInfo : Form
    {
        public int idDOC=0;
        public FormAlterarInfo()
        {
            InitializeComponent();
        }

        private void txt_ano_doc_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ano_doc_i.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_doc_i.Text = " ";
                txt_ano_doc_i.Text = "000";

            }
        }

        private void txt_mes_doc_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_mes_doc_i.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes_doc_i.Text = " ";
                txt_mes_doc_i.Text = "0";

            }
        }

        private void txt_dia_doc_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_dia_doc_i.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia_doc_i.Text = " ";
                txt_dia_doc_i.Text = "0";

            }
        }

        private void txt_ano_doc_V_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ano_doc_v.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_doc_v.Text = " ";
                txt_ano_doc_v.Text = "0";

            }
        }

        private void txt_mes_doc_v_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_mes_doc_v.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes_doc_v.Text = " ";
                txt_mes_doc_v.Text = "0";

            }
        }

        private void txt_dia_doc_v_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_dia_doc_v.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia_doc_v.Text = " ";
                txt_dia_doc_v.Text = "0";

            }
        }

        private void FormAlterarInfo_Load(object sender, EventArgs e)
        {
            panel_alterar_documento_info.Visible = false;
            combo_menu_alterar.Text = "INFORMAÇÕES DE PESSOAS";
            panel_alterar_pessoa_info.Visible = true;
            panel_alterar_data_pessoa.Visible = false;

        }

        private void combo_menu_alterar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_menu_alterar.Text)
            {
                case "INFORMAÇÕES DE DOCUMENTOS":
                    MessageBox.Show("INFORMAÇÕES DE DOCUMENTOS");
                    panel_alterar_pessoa_info.Visible = false;
                    panel_alterar_documento_info.Visible = true;
                    panel_alterar_data_documento.Visible = false;



                    break;

                case "INFORMAÇÕES DE PESSOAS":
                    MessageBox.Show("INFORMAÇÕES DE PESSOAS");
                    panel_alterar_documento_info.Visible = false;
                    panel_alterar_pessoa_info.Visible = true;
                    panel_alterar_data_pessoa.Visible = false;


                    break;

                default:

                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 formulario = new Form1();
            this.Hide();
            formulario.ShowDialog();
            this.Close();


        }

        private void button9_Click(object sender, EventArgs e)
        {
           
                    panel_alterar_data_documento.Visible = true;
                    panel_data_validade.Visible = false;
                    panel_data_insercao.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
               
                    panel_alterar_data_documento.Visible = true;
                    panel_data_insercao.Visible = false;
                    panel_data_validade.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Aterar Nome
            Pessoa nome = new Pessoa();
            nome.alterarNome();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Alterar sexo
            Pessoa sexo = new Pessoa();
            sexo.alterarSexo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Alterar email
            Pessoa email = new Pessoa();
            email.alterarEmail();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Alterar telefone
            Pessoa telefone = new Pessoa();
            telefone.alterarTelefone();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Alterar data de nascimento
            panel_alterar_data_pessoa.Visible = true;


        }

        //Documentos
        private void button10_Click(object sender, EventArgs e)
        {
            //Alterar descricao
            Pessoa doc = new Pessoa();
            doc.alterarDescricao();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Alterar tipo
            Pessoa doc = new Pessoa();
            doc.alterarTipo();
        }

        private void txt_ano_inserir_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txt ano inserir
            if (txt_ano_inserir.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_inserir.Text = " ";
                txt_ano_inserir.Text = "000";

            }
        }

        private void txt_mes_inserir_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txt mes inserir
            if (txt_mes_inserir.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes_inserir.Text = " ";
                txt_mes_inserir.Text = "0";

            }

        }

        private void txt_dia_inserir_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txt dia inserir
            if (txt_dia_inserir.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia_inserir.Text = " ";
                txt_dia_inserir.Text = "0";

            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //actualizar data de nascimento pessoa
            if (
               txt_ano_doc_i.Text.Length == 0 || txt_dia_doc_i.Text.Length == 0 || txt_mes_doc_i.Text.Length == 0)
            {

                MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                /* Pessoa doc = new Pessoa();
                 string dataI = $"{txt_ano_doc_i.Text}-{txt_mes_doc_i.Text}-{txt_dia_doc_i.Text}";*/
                try
                {
                    Pessoa p1 = new Pessoa();

                    idDOC = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
             "", "", 480, 174));

                    if (p1.existe(idDOC))
                    {
                        string dataI = $"{txt_ano_doc_i}-{txt_mes_doc_i.Text}-{txt_dia_doc_i.Text}";
                        p1.alterarDataPessoa(dataI, idDOC);
                    }
                    else
                    {
                        MessageBox.Show("PESSOA NÃO ENCONTRADA!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }




                //Chamada do metodo

            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            //Actualizar data documento

            if (panel_data_insercao.Visible)
            {
                if (
             txt_ano_inserir.Text.Length == 0 || txt_dia_inserir.Text.Length == 0 || txt_mes_inserir.Text.Length == 0)
                {

                    MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        Pessoa p1 = new Pessoa();

                        idDOC = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO DOCUMENTO!",
                 "", "", 480, 174));

                        if (p1.docExiste(idDOC))
                        {
                            string dataI = $"{txt_ano_inserir.Text}-{txt_mes_inserir.Text}-{txt_dia_inserir.Text}";
                            p1.alterarDataInsercao(dataI, idDOC);
                        }
                        else
                        {
                            MessageBox.Show("DOCUMENTO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODOS OS DOCUMENTOS CADASTRADOS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }catch(Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                   
                     
                }
            }
            else if(panel_data_validade.Visible)
            {
                if (
              txt_ano_doc_v.Text.Length == 0 || txt_dia_doc_v.Text.Length == 0 || txt_mes_doc_v.Text.Length == 0)
                {

                    MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    try
                    {
                        Pessoa p1 = new Pessoa();

                        idDOC = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO DOCUMENTO!",
                 "", "", 480, 174));

                        if (p1.docExiste(idDOC))
                        {
                           
                            string datav = $"{txt_ano_doc_v.Text}-{txt_mes_doc_v.Text}-{txt_dia_doc_v.Text}";
                            p1.alterarDataValidade(datav, idDOC);
                        }
                        else
                        {
                            MessageBox.Show("DOCUMENTO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODOS OS DOCUMENTOS CADASTRADOS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }

                }
            }
            
        }
    }
}
/*


    */
