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
    public partial class Form1 : Form
    {
        public int id=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_menu.Text)
            {
                case "CADASTRAR PESSOAS":

                   
                    dataGridView_dados.Visible = false;
                    panel_remover_data.Visible = false;
                    panel_cadastrar_documentos.Visible = false;
                    panel_cadastrar_pessoa.Visible = true;

                    break;

                case "CADSTRAR DOCUMENTOS":
                   

                    Pessoa pessoa = new Pessoa();

                    try
                    {
                         id = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO DO DOCUMENTO!",
                        "", "", 480, 174));

                        if (pessoa.existe(id))
                        {
                            dataGridView_dados.Visible = false;
                            panel_remover_data.Visible = false;
                            panel_cadastrar_pessoa.Visible = false;
                            panel_cadastrar_documentos.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("OPERAÇÃO CANCELADA OU VALOR DO TIPO INVÁLIDO ", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case "EXCLUIR PESSOAS":

                   
                    Pessoa excluir = new Pessoa();
                    excluir.excluir_pessoa();
                    break;

                case "EXCLUIR DOCUMENTOS":

                   
                    Pessoa exclDoc = new Pessoa();
                    panel_remover_data.Visible = false;
                    exclDoc.excluir_documento();

                    break;

                case "EXCLUIR DOCUMENTOS POR PERIODO":

                    
                    dataGridView_dados.Visible = false;
                    panel_cadastrar_documentos.Visible = false;
                    panel_cadastrar_pessoa.Visible = false;
                    panel_remover_data.Visible = true;

                    break;

                case "ALTERAR INFORMAÇÕES":

                   

                    FormAlterarInfo formulario = new FormAlterarInfo();
                    this.Hide();
                    formulario.ShowDialog();
                    this.Show();
                    break;

                case "TOTAL DE DOCUMENTOS DE UMA PESSOA":

                   
                    Pessoa p = new Pessoa();
                    p.totalDocumentos();

                    break;

                case "PESSOA COM MAIS DOCUMENTOS":

                   
                    Pessoa tota = new Pessoa();
                    tota.pessoa_com_mais_documento();

                    break;

                case "VER TODAS AS PESSOAS CADASTRADAS":

                   
                    Pessoa pessoasC = new Pessoa();
                    panel_cadastrar_documentos.Visible = false;
                    panel_remover_data.Visible = false;
                    panel_cadastrar_pessoa.Visible = false;
                    dataGridView_dados.DataSource = pessoasC.todasAsPessoas();
                    dataGridView_dados.Visible = true;
                    break;

                case "VER TODOS OS DOCUMENTOS CADASTRADOS":

                   
                    Pessoa DocumentoC = new Pessoa();
                    panel_remover_data.Visible = false;
                    panel_cadastrar_documentos.Visible = false;
                    panel_cadastrar_pessoa.Visible = false;
                    dataGridView_dados.DataSource = DocumentoC.verTodosDocumentos();
                    dataGridView_dados.Visible = true;

                    break;


                default:

                    MessageBox.Show("SELECIONE UMA OPÇÃO NO MENU");

                    break;
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_cadastrar_pessoa.Visible = true;
            panel_cadastrar_documentos.Visible = false;
            panel_remover_data.Visible = false;
            dataGridView_dados.Visible = false;
        }

        private void txt_ano_doc_i_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ano_doc_i.Text.Length >4 || char.IsLetter(e.KeyChar))
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

        private void txt_dia_doc_i_TextChanged(object sender, EventArgs e)
        {

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
            if (txt_ano_doc_V.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_doc_V.Text = " ";
                txt_ano_doc_V.Text = "0";

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

        private void txt_dia_doc_v_TextChanged(object sender, EventArgs e)
        {

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

        private void txt_ano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ano.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano.Text = " ";
                txt_ano.Text = "000";

            }
        }

        private void txt_mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_mes.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes.Text = " ";
                txt_mes.Text = "0";

            }
        }

        private void txt_dia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_dia.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia.Text = " ";
                txt_dia.Text = "0";

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Cadastrar Pessoas

            if (txt_nome.Text.Length==0|| txt_email.Text.Length==0|| txt_telefone.Text.Length==0
                || txt_ano.Text.Length==0|| txt_mes.Text.Length==0|| txt_dia.Text.Length==0|| combo_sexo.Text.Length==0
                || Convert.ToInt16(txt_dia.Text)>31|| Convert.ToInt16(txt_mes.Text)>12)
            {
                MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                    "",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string data = $"{txt_ano.Text}-{txt_mes.Text}-{txt_dia.Text}";
                Pessoa pessoa = new Pessoa(txt_nome.Text, Convert.ToChar(combo_sexo.Text),
                    txt_email.Text, data, txt_telefone.Text);

                     
                //Metodo que envia os dados para o banco de dados.
                      pessoa.cadastrarPessoa();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cadstrar documentos

            if (txt_descricao.Text.Length==0|| txt_tipo.Text.Length==0||
                txt_dia_doc_i.Text.Length==0||txt_mes_doc_i.Text.Length==0||txt_ano_doc_i.Text.Length==0||
                txt_ano_doc_V.Text.Length==0||txt_dia_doc_v.Text.Length==0|| txt_mes_doc_v.Text.Length==0)
            {

                MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToInt16(txt_ano_doc_i.Text)> Convert.ToInt16(txt_ano_doc_V.Text))
                {
                    MessageBox.Show("A DATA DE INSERÇÃO NÃO PODE SER MAIOR QUE A DATA DE VALIDADE!",""
                        ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    Pessoa doc = new Pessoa();
                string dataI = $"{txt_ano_doc_i.Text}-{txt_mes_doc_i.Text}-{txt_dia_doc_i.Text}";
                string dataV = $"{txt_ano_doc_V.Text}-{txt_mes_doc_v.Text}-{txt_dia_doc_v.Text}";
                doc.cadastrarDocumentos(id, txt_descricao.Text, txt_tipo.Text, dataI, dataV);
                }
                
            }
           

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remover data

            if (
                txt_ano_remover_i.Text.Length == 0 || txt_mes_remover_i.Text.Length == 0 || txt_dia_remover_i.Text.Length == 0 ||
                txt_ano_remover_f.Text.Length == 0 || txt_dia_remover_f.Text.Length == 0 || txt_mes_remover_f.Text.Length == 0)
            {

                MessageBox.Show("ERRO, VERIFIQUE OS DADOS E TENTE NOAMENTE!",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToInt16(txt_ano_remover_i.Text) > Convert.ToInt16(txt_ano_remover_f.Text))
                {
                    MessageBox.Show("A DATA DE INSERÇÃO NÃO PODE SER MAIOR QUE A DATA DE VALIDADE!", ""
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Pessoa remover = new Pessoa();
                    string dataI = $"{txt_ano_remover_i.Text}-{txt_mes_remover_i.Text}-{txt_dia_remover_i.Text}";
                    string dataf = $"{txt_ano_remover_f.Text}-{txt_mes_remover_f.Text}-{txt_dia_remover_f.Text}";
                    remover.excluir_documentos_por_periodo(dataI, dataf);
                    
                }

            }
        }

        private void panel_remover_data_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_ano_remover_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            //remover ano
            if (txt_ano_remover_i.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_remover_i.Text = " ";
                txt_ano_remover_i.Text = "000";

            }

        }

        private void txt_mes_remover_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            //remover mes
            if (txt_mes_remover_i.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes_remover_i.Text = " ";
                txt_mes_remover_i.Text = "0";

            }
        }

        private void txt_dia_remover_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            // remover dia
            if (txt_dia_remover_i.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia_remover_i.Text = " ";
                txt_dia_remover_i.Text = "0";

            }
        }

        private void txt_ano_remover_f_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ano_remover_f.Text.Length > 4 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 4 OU LETRAS");
                txt_ano_remover_f.Text = " ";
                txt_ano_remover_f.Text = "000";

            }

        }

        private void txt_mes_remover_f_KeyPress(object sender, KeyPressEventArgs e)
        {
            //remover mes
            if (txt_mes_remover_f.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_mes_remover_f.Text = " ";
                txt_mes_remover_f.Text = "0";

            }
        }

        private void txt_dia_remover_f_KeyPress(object sender, KeyPressEventArgs e)
        {
            // remover dia
            if (txt_dia_remover_f.Text.Length > 2 || char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("NÃO É PERMITIDO VALORES SUPERIORES A 2 OU LETRAS");
                txt_dia_remover_f.Text = " ";
                txt_dia_remover_f.Text = "0";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}







