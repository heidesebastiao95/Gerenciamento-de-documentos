using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace exercicio3ConexaoBD
{
    class Pessoa
    {

        #region Variaveis de instancias
        //*************************

        private MySqlConnection conexao;
        private MySqlCommand cmd;
        private MySqlDataAdapter adptador;
        private MySqlDataReader reader;
        private DataTable tabela;

        //**************************

        private string query = "";
        private string caminho = "server=localhost;uid=root;password=;database=exercicio3;convert zero datetime=True;";
        //Dados do usuario
        private string nome;
        private char sexo;
        private string email;
        private string data;
        private string telefone;
        //*******************

        #endregion

        #region Construtor
        public Pessoa()
        {

        }

        public Pessoa(string nome, char sexo, string email, string data, string telefone)
        {
            this.nome = nome;
            this.sexo = sexo;
            this.email = email;
            this.data = data;
            this.telefone = telefone;
        }
        #endregion

        #region Cadastrar pessoa

        public void cadastrarPessoa()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        query = $"insert into  proprietarios values('Default','{this.nome}','{this.sexo}','{this.email}','{this.data}','{this.telefone}')";
                        cmd = new MySqlCommand(query, this.conexao);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("OPERAÇÃO BEM SUCEDIDA", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conexao.Close();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("ERRO VERIFIQUE OS DADOS!");
                    }


                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO"); ;
            }
        }

        #endregion

        #region Cadastrar documentos
        public void cadastrarDocumentos(int idUsuario,string descricao, 
            string tipo, string data_insercao, string data_validade)
        {


            try
            {
                
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                   
                    try
                    {
                       
                        int cod_documento = Convert.ToInt16(codigoDocumento(idUsuario));
                        query = $"insert into documentos values('{cod_documento}','{descricao}','{tipo}','{data_validade}','{data_insercao}')";
                        cmd = new MySqlCommand(query, this.conexao);
                        cmd.ExecuteNonQuery();
                        conexao.Close();

                        //registra o documento
                        registro(idUsuario, cod_documento);


                        MessageBox.Show("OPERAÇAO BEM SUCEDIDA!", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception erro)
                    {
                      
                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }
                   
                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {
                
                MessageBox.Show(erro.ToString());
                conexao.Close();
            }
        }

        #region registro
        public void registro(int id_prop,int cod_doc)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                query = $"insert into registros values('Default','{id_prop}','{cod_doc}');";
                cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.ToString());
                conexao.Close();
            }
        }
        #endregion

        #region Obter codigo do documento
        public string codigoDocumento(int idUsuario)
        {
            string codigoDocumento = "";
            int cont = 1;
            try
            {
                
                string query = $" select count(id_prop) from registros where id_prop='{idUsuario}';";
                cmd = new MySqlCommand(query, this.conexao);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cont += reader.GetInt16(0);
                }

                codigoDocumento = $"{idUsuario}{cont}";
                reader.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.ToString());
            }
            return codigoDocumento;
        }
        #endregion

        #region Usuario existe?
        public bool existe(int id)
        {
            int cont = 0;

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        query = $"select count(id_prop) from proprietarios where id_prop={id};";
                        cmd = new MySqlCommand(query, this.conexao);
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cont = reader.GetInt16(0);
                        }
                        conexao.Close();

                        if (cont == 1)
                        {
                            return true;
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }
                   
                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
            return false;

        }
        #endregion
        #endregion

        #region Ver todas as pessoas
        public DataTable todasAsPessoas()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    query = $"select *from proprietarios;";
                    tabela = new DataTable();
                    adptador = new MySqlDataAdapter(query, this.conexao);
                    adptador.Fill(tabela);
                    return tabela;
                    


                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                    conexao.Close();
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.ToString());
                conexao.Close();
            }

            return tabela;
        }
        #endregion

        #region Ver todos os documentos
        public DataTable verTodosDocumentos()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    query = $"select *from documentos;";
                    tabela = new DataTable();
                    adptador = new MySqlDataAdapter(query, this.conexao);
                    adptador.Fill(tabela);
                    return tabela;



                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
            }

            return tabela;
    }
        #endregion

        #region Excluir pessoas
        public void excluir_pessoa()
        { 
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        
                        int idUsuario = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
                   "", "", 480, 174));

                        if (existe(idUsuario))
                        {
                            conexao.Open();
                            query = $"delete p,d from proprietarios as p join registros as r on p.id_prop=r.id_prop join documentos as d on r.cod_doc=d.cod_doc where p.id_prop='{idUsuario}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("USUARIO EXLCUIDO", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("OPERÇÃO CANCELADA OU VALORES DO TIPO INVÁLIDO");
                        conexao.Close();
                    }
               

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
        }
        #endregion

        #region Documento existe?
        public bool docExiste(int idDoc)
        {

            int cont = 0;

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        query = $"select count(cod_doc) from documentos where cod_doc={idDoc};";
                        cmd = new MySqlCommand(query, this.conexao);
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cont = reader.GetInt16(0);
                        }
                        conexao.Close();

                        if (cont == 1)
                        {
                            return true;
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
            return false;
        }
        #endregion

        #region excluir documento
        public void excluir_documento()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {

                        int idDoc = Convert.ToInt16(Interaction.InputBox("INSIRA O CODIGO DO DOCUMENTO!",
                   "", "", 480, 174));

                        if (docExiste(idDoc))
                        {
                            conexao.Open();
                            query = $"delete from documentos where cod_doc='{idDoc}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DOCUMENTO EXCLUIDO", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("DOCUMENTO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODOS OS DOCUMENTOS CADASTRADOS'", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("OPERAÇÃO CANCELADA OU VALORES DO TIPO INVÁLIDOS");
                        conexao.Close();
                    }


                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
        }
        #endregion

        #region Excluir documentos por periodo
        public void excluir_documentos_por_periodo(string dataInicial,string dataFinal)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        if (docExisteData(dataInicial,dataFinal))
                        {
                            conexao.Open();
                            query = $"delete from documentos where data_insercao>='{dataInicial}' and data_validade<='{dataFinal}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DOCUMENTO(s) EXCLUIDO(s)", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("DOCUMENTO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODOS OS DOCUMENTOS CADASTRADOS'", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }


                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
        }

        #region Documentos nesta data existem?
        private bool docExisteData(string dataInicial,string dataFinal)
        {
            int cont = 0;

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        query = $"select count(cod_doc) from documentos where data_insercao>='{dataInicial}' and data_validade<='{dataFinal}';";
                        cmd = new MySqlCommand(query, this.conexao);
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cont = reader.GetInt16(0);
                        }
                        conexao.Close();

                        if (cont >= 1)
                        {
                            return true;
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
                conexao.Close();
            }
            
       
            return false;
        }
        #endregion
        #endregion

        #region Total de documentos

        public void totalDocumentos()
        {
            int cont = 0;
            string nome = "";
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idusuario = Convert.ToInt16(Interaction.InputBox("INSIRA O CODIGO DO PROPIETARIO!",
                   "", "", 480, 174));
                        if (existe(idusuario))
                        {
                            conexao.Open();
                            query = $"select count(cod_doc) from registros where id_prop='{idusuario}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                cont = reader.GetInt16(0);
                                
                            }
                            conexao.Close();

                            try
                            {
                                conexao.Open();
                                query = $"select nome_prop from proprietarios where id_prop={idusuario};";
                                cmd = new MySqlCommand(query, conexao);
                                reader=cmd.ExecuteReader();

                                while (reader.Read())
                                {
                                    nome = reader.GetString(0);

                                }

                                
                            }
                            catch (Exception erro)
                            {

                                MessageBox.Show(erro.ToString());
                            }

                            MessageBox.Show($"O SENHOR {nome} POSSUI {cont} DOCUMENTO(S) CADASTRADOS","",
                                MessageBoxButtons.OK,MessageBoxIcon.Information);
                            conexao.Close();

                        }
                        else
                        {
                            MessageBox.Show($"PESSOA NÃO ENCONTRADA, VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO NA CONEXAO");
            }
        }

        #endregion

        #region Pessoa com mais documentos

        public void pessoa_com_mais_documento()
        {
            string nome = "";
            int quant = 0;

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        query = $"SELECT p.nome_prop, count(*) FROM registros as r join proprietarios as p on p.id_prop=r.id_prop GROUP BY r.id_prop  limit 1;";
                        cmd = new MySqlCommand(query, this.conexao);
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            nome = reader.GetString(0);
                            quant = reader.GetInt16(1);
                            
                        }
                        MessageBox.Show($"A PESSOA COM MAIS DOCUMENTOS CADASTRADOS É {nome} com {quant} documento(s)");
                        conexao.Close();
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.ToString());
                        conexao.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.ToString()); 
            }
        }

        #endregion

        #region Alterar informações

        #region Pessoas
        #region Alterar nome

        public void alterarNome()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idUsuario = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
                  "", "", 480, 174));

                        if (existe(idUsuario))
                        {
                            conexao.Open();
                            string nome = Interaction.InputBox("INSIRA O NOVO NOME!",
                 "", "", 480, 174);

                            query = $"update proprietarios set nome_prop='{nome}' where id_prop='{idUsuario}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion

        #region Alterar sexo
        public void alterarSexo()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idUsuario = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
                  "", "", 480, 174));

                        if (existe(idUsuario))
                        {
                            conexao.Open();
                            string sexo = Interaction.InputBox("INSIRA O NOVO GÊNERO (M OU F)!",
                 "", "", 480, 174);

                            if (Convert.ToChar(sexo) == 'M' || Convert.ToChar(sexo) == 'F')
                            {
                                query = $"update proprietarios set sexo='{sexo}' where id_prop='{idUsuario}';";
                                cmd = new MySqlCommand(query, this.conexao);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conexao.Close();
                            }
                            else
                            {
                                MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conexao.Close();
                            }

                        }
                        else
                        {

                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }

        #endregion

        #region Alterar email
        public void alterarEmail()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idUsuario = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
                  "", "", 480, 174));

                        if (existe(idUsuario))
                        {
                            conexao.Open();
                            string email = Interaction.InputBox("INSIRA O NOVO Email!",
                 "", "", 480, 174);

                            query = $"update proprietarios set email='{email}' where id_prop='{idUsuario}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion

        #region Alterar telefone
        public void alterarTelefone()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idUsuario = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO PROPRIETARIO!",
                  "", "", 480, 174));

                        if (existe(idUsuario))
                        {
                            conexao.Open();
                            string telefone = Interaction.InputBox("INSIRA O NOVO Telefone!",
                 "", "", 480, 174);

                            query = $"update proprietarios set telefone='{telefone}' where id_prop='{idUsuario}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion

        #region Alterar data
        public void alterarDataPessoa(string data, int idDoc)
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {



                        query = $"update proprietarios set data_nascimento='{data}' where id_prop='{idDoc}';";
                        cmd = new MySqlCommand(query, this.conexao);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conexao.Close();

                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion
        #endregion

        #region Documentos

        #region alterar descrição
        public void alterarDescricao()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idDOC = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO DOCUMENTO!",
                  "", "", 480, 174));

                        if (docExiste(idDOC))
                        {
                            conexao.Open();
                            string desc_doc = Interaction.InputBox("INSIRA A NOVA DESCRIÇÃO DO DOCUMENTO!",
                 "", "", 480, 174);

                            query = $"update documentos set desc_doc='{desc_doc}' where cod_doc='{idDOC}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }

        #endregion

        #region Alterar tipo
        public void alterarTipo()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        int idDOC = Convert.ToInt16(Interaction.InputBox("INSIRA O ID DO DOCUMENTO!",
                  "", "", 480, 174));

                        if (docExiste(idDOC))
                        {
                            conexao.Open();
                            string desc_doc = Interaction.InputBox("INSIRA O NOVO TIPO PARA O DO DOCUMENTO!",
                 "", "", 480, 174);

                            query = $"update documentos set desc_doc='{desc_doc}' where cod_doc='{idDOC}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("USUARIO NÃO ENCONTRADO!,VERIFIQUE EM 'VER TODAS AS PESSOAS CADASTRADAS'", "",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
                        }
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion

        #region Alterar data de insercao
        public void alterarDataInsercao(string data,int idDoc)
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    {
                        


                            query = $"update documentos set data_insercao='{data}' where cod_doc='{idDoc}';";
                            cmd = new MySqlCommand(query, this.conexao);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();
   
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion

        #region Alterar data validade

        public void alterarDataValidade(string data, int idDoc)
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    try
                    { 
                        query = $"update documentos set data_validade='{data}' where cod_doc='{idDoc}';";
                        cmd = new MySqlCommand(query, this.conexao);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("DADOS ACTUALIZADOS!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conexao.Close();

                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show("DADOS INVÁLIDOS OU OPERAÇÃO CANCELADA");
                        conexao.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA CONEXAO");
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO AO ACTUALIZAR");
            }
        }
        #endregion
        #endregion

        #endregion
    }
}
