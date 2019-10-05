var self;

function Listar() {
    self = this;
    self._idchamado = $("#idchamado");
    self._idTecnico = $("#idTecnico");
    self._idchamadoF = $("#idchamadoF");
    self._idTecnicoF = $("#idTecnicoF");
    self._selectEquipamento = $("#selectEquipamento");
}

Listar.prototype.carregarSolicitacao = function (event, obj) {

    if (event != undefined)
        event.preventDefault();

    solicitacaoService.carregarSolicitacao({

    }, function (result) {
        self._montarTabela(result);
    });
}

Listar.prototype._montarTabela = function (lista){

    var html = `<div class='table-responsive'>
                   <h3>Listagem de Chamados</h3>
                    <table id="products-table" class="table table-hover table-bordered">
                        <tbody>
                            <tr>
                                <th>Código da Solicitacao</th>
                                <th>Status</th>
                                <th>Descricao</th>
                            </tr>
                            <tr>
                                ${this._montarlinhas(lista)}
                            </tr>
                        </tbody>
                    </table>
                </div>`

document.querySelector("#tablesoli").innerHTML = html
}

Listar.prototype._montarlinhas = function (lista) {
    var html = ``

    lista.forEach(function (item) {
        html += `<tr>
                     <td>${item.SolicitacaoId}</td>
                     <td>${item.Status}</td>
                     <td>${item.Descricao}</td>               
                </tr>`});
    return html
}

Listar.prototype.carregarAtendimentos = function (event, obj) {
    if (event != undefined)
        event.preventDefault();

    solicitacaoService.carregarAtendimento({

    }, function (result) {
            self._montarTabelaAted(result);
    });
}

Listar.prototype.iniciarAtendimento = function (event, obj) {

    event.preventDefault();
    solicitacaoService.iniciarAtendimento({
        idchamado: self._idchamado.val(),
        idTecnico: self._idTecnico.val()
    }, function (result) {
            if (result == 200) {

                alert("Atendimento Iniciado com Sucesso ");
                self.carregarAtendimentos();

            } else {

                alert("Atendimento Já Iniciado ");
                self.carregarAtendimentos();
            }   
    });
}

Listar.prototype._montarTabelaAted = function (lista) {

    var html = `<div class='table-responsive'> 
                  <h3>Listagem de Atendimentos</h3>
                    <table id="table-atendimento" class="table table-hover table-bordered">
                        <tbody>
                            <tr>
                                <th>Código da Atendimento</th>
                                <th>Código da Solicitacao</th>
                                <th>Código do Tecnico</th>
                                <th>Data Inicio</th>
                                <th>Data Fim</th>
                                <th>Troca Equipamento</th>
                            </tr>
                            <tr>
                                ${this._montarlinhasAted(lista)}
                            </tr>
                        </tbody>
                    </table>
                </div>`

    document.querySelector("#tableated").innerHTML = html
}

Listar.prototype._montarlinhasAted = function (lista) {
    var html = ``

    lista.forEach(function (item) {
        html += `<tr>
                     <td>${item.AtedimentoId}</td>
                     <td>${item.SolicitacaoId}</td>
                     <td>${item.CodigoTecnico}</td>
                     <td>${moment(item.DataInicio).format('DD-MM-YYYY')}</td>
                     <td>${moment(item.DataFim).format('DD-MM-YYYY')}</td>
                     <td>${item.TrocaEquipamento}</td> 
                </tr>`});
    return html
}

Listar.prototype.finalizarAtendimento = function (event, obj) {

    event.preventDefault();
    solicitacaoService.finalizarAtendimento({
        idchamado: self._idchamadoF.val(),
        idTecnico: self._idTecnicoF.val(),
        equipamento: self._selectEquipamento.val()
    }, function (result) {
            if (result == 200) {

                alert("Atendimento Finalizado com Sucesso ");
                self.carregarSolicitacao();
                self.carregarAtendimentos();

            } else {

                alert("Atendimento Já Finalizado ");
                self.carregarSolicitacao();
                self.carregarAtendimentos();
            }   
    });
}
listar = new Listar();