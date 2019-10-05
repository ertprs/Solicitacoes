function SolicitacaoService() {

    SolicitacaoService.prototype.carregarSolicitacao = function (data, callback) {

        var url = "/solicitacao/CarregarSolicitacoes";
        $.ajax({
            type: "get",
            url: url,
            success: callback
        });
    }

    SolicitacaoService.prototype.carregarAtendimento = function (data, callback) {

        var url = "/Solicitacao/CarregarAtendimento"
        $.ajax({
            type: "get",
            url: url,
            data: data,
            success: callback
        });
    }

    SolicitacaoService.prototype.iniciarAtendimento = function (data, callback) {
        var url = "/solicitacao/IniciarAtendimento"
        $.ajax({
            type: "get",
            url: url,
            data:data,
            success: callback
        });
    }

    SolicitacaoService.prototype.finalizarAtendimento = function (data, callback) {
        var url = "/solicitacao/FinalizarAtendimento"
        $.ajax({
            type: "get",
            url: url,
            data: data,
            success: callback
        });
    }

}

solicitacaoService = new SolicitacaoService