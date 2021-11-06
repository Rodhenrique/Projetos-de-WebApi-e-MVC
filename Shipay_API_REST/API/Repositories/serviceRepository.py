from flask import Response
import json

class service():
    def generate_response(status, nome_do_conteudo=False, conteudo =False, mensagem=False):
        body = {}
        if nome_do_conteudo:
            body[nome_do_conteudo] = conteudo

        if(mensagem):
            body["Mensagem"] = mensagem

        return Response(json.dumps(body), status=status, mimetype="application/json")