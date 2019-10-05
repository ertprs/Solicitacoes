
using Dapper;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Contexto;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Repository.Repositorys
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        protected Context context;

        public void Adiciona(Solicitacao solicitacao)

        {
            string sql = string.Format($@" DECLARE 
                                       @STATUS VARCHAR(55)={solicitacao.Status},
                                       @DESCRICAO VARCHAR(100)={solicitacao.Descricao},
                                       @CODIGOTEC INT = {solicitacao.CodTecnico}

                                      INSERT INTO SOLICITACAO (STATUSSOLICITACAO,DESCRICAO,CODTECNICO)VALUES(@STATUS,@DESCRICAO,@CODIGOTEC)");

            using(var connection = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True"))
            {
                connection.Query<Solicitacao>(sql: sql);
            }
        }

        public int FinalizarAtendimento(string idchamado, string idTecnico,string equipamento)
        {
            string sql = string.Format($@"
                                       BEGIN TRANSACTION 
                                            BEGIN TRY
		                                        DECLARE 
		                                        @idatendimento int = {idchamado},
		                                        @idcodigotecnico int ={idTecnico},
		                                        @trocaequipamento int={equipamento}

		                                        IF((SELECT COUNT(*) FROM ATENDIMENTO WHERE ATENDIMENTO.ATENDIMENTOID = @idatendimento AND ATENDIMENTO.STATUSFIN = 0 )>0)
													BEGIN 
														UPDATE 
															SOLICITACAO
																 SET DESCRICAO = 'FINALIZADO',
																	STATUSSOLICITACAO = 'FINALIZADO'
														FROM 
															ATENDIMENTO
														INNER JOIN SOLICITACAO
															 ON SOLICITACAO.ID = ATENDIMENTO.SOLICITACAO
														WHERE
															 ATENDIMENTO.ATENDIMENTOID =@idatendimento

														UPDATE
															 ATENDIMENTO 
																SET STATUSFIN = 1,
																	TROCAEQUIPAMENTO = @trocaequipamento,
                                                                    DATAFIM = GETDATE() 
														FROM
															ATENDIMENTO
														WHERE 
														ATENDIMENTO.ATENDIMENTOID =  @idatendimento

														SELECT 200 AS RESULTADO 
													END
													ELSE
														BEGIN
															SELECT 400 AS RESULTADO
														END
                                              COMMIT TRANSACTION 
	                                         END TRY 
                                        BEGIN CATCH 
                                            ROLLBACK 
                                        END CATCH ");

            using (var connection = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True"))
            {
                return connection.QueryFirstOrDefault<int>(sql: sql);
            }

        }

        public int IniciarAtendimento(string idchamado, string idTecnico)
        {
            string sql = string.Format($@"
                                          BEGIN TRANSACTION 
                                            BEGIN TRY 

                                            DECLARE 
                                            @IDCMADO INT = {idchamado}, 
                                            @CODIGOTEC INT = {idTecnico}

                                            IF ((SELECT COUNT(*) FROM SOLICITACAO SOLI WHERE SOLI.ID = @IDCMADO AND SOLI.STATUSSOLICITACAO LIKE ('ABERTA')) > 0)

	                                            BEGIN 
		                                            UPDATE
														 SOLICITACAO
															SET STATUSSOLICITACAO = 'ATENDIMENTO' 
													WHERE 
														SOLICITACAO.ID = @IDCMADO

		                                            INSERT INTO 
														ATENDIMENTO 
															(SOLICITACAO,CODTEC,DATAINICIO,STATUSFIN)
														VALUES
															(@IDCMADO,@CODIGOTEC,GETDATE(),0);

		                                            SELECT 200 AS RESULTADO 
	                                            END

                                            ELSE
												BEGIN 
													SELECT 400 AS RESULTADO 
												END

                                            COMMIT TRANSACTION 
                                            END TRY
                                            BEGIN CATCH

	                                            ROLLBACK 

                                            END CATCH");

            using (var connection = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True"))
            {
                return connection.QueryFirstOrDefault<int>(sql: sql);
            }
        }

        public List<Solicitacao> ListarSolicitacao()
        {
            string sql = string.Format($@"SELECT SOLI.ID AS SolicitacaoId, SOLI.STATUSSOLICITACAO AS Status,SOLI.DESCRICAO AS Descricao,SOLI.CODTECNICO AS CodTecnico FROM SOLICITACAO SOLI");

            using (var connection = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True"))
            {

                return  connection.Query<Solicitacao>(sql: sql).ToList();                
            }
        }

        public List<Atendimento> CarregarAtendimento()
        {
            string sql = string.Format($@"
                                        SELECT
											 ATENDIMENTOID AS AtedimentoId,
											 SOLICITACAO AS SolicitacaoId,
											 CODTEC AS CodigoTecnico,
											 DATAINICIO AS DataInicio,
											 DATAFIM AS DataFim,
											 TROCAEQUIPAMENTO AS TrocaEquipamento
										FROM 
											ATENDIMENTO ");
            using (var connection = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True"))
            {

                return connection.Query<Atendimento>(sql: sql).ToList();
            }
        }

    }
}
