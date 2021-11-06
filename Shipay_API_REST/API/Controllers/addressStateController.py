from flask import Blueprint, request
from Repositories.addressStateRepository import addressStateRepository
from Repositories.serviceRepository import service
from Models.addressState import address_states

addressStates = Blueprint('addressStates', __name__)

@addressStates.route('/addressStates', methods=["get"])
def Get():
    listStates = addressStateRepository.Get()

    return service.generate_response(200, "AddressStates", listStates)

@addressStates.route('/addressStates/<id>', methods=["get"])
def GetById(id):
    state = addressStateRepository.GetById(id)
    if state == False:
        return service.generate_response(400, False, False, "An error has occurred!!!")

    try:
        return service.generate_response(200, "AddressStates", state)
    except:
        return service.generate_response(400, False, False, "An error has occurred!!!")


@addressStates.route('/addressStates', methods=["post"])
def Post():
    body = request.get_json()

    state = address_states(name = body["name"],uf = body["uf"])

    verify = addressStateRepository.Post(state)
    if verify :
        return service.generate_response(201, False, False, "registered successfully!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

@addressStates.route('/addressStates/<id>', methods=["put"])
def Put(id):
    body = request.get_json()

    state = address_states(name = body["name"],uf = body["uf"])

    verify = addressStateRepository.Put(id,state)
    if verify :
        return service.generate_response(200, False, False, "Updated successfully!!!")
    else:
        return service.generate_response(400, "AddressStates", {}, "An error has occurred!!!")

@addressStates.route('/addressStates/<id>', methods=["DELETE"])
def Delete(id):
    verify = addressStateRepository.Delete(id)
    if verify :
        return service.generate_response(200, False, False, "successfully deleted!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

