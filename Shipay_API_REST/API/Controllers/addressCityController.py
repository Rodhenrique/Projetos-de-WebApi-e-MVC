from Models.addressCities import address_cities
from flask import Blueprint, request
from Repositories.addressCityRepository import addressCitiesRepository
from Repositories.serviceRepository import service

addressCities = Blueprint('addressCities', __name__)

@addressCities.route('/addressCities', methods=["get"])
def Get():
    ListAdresses = addressCitiesRepository.Get()

    return service.generate_response(200, "AddressCities", ListAdresses)

@addressCities.route('/addressCities/<id>', methods=["get"])
def GetById(id):
    adress = addressCitiesRepository.GetById(id)

    return service.generate_response(200, "AddressCities", adress)

@addressCities.route('/addressCities', methods=["post"])
def Post():
    body = request.get_json()

    adress = address_cities(name = body["name"],address_state_id = body["address_state_id"])

    verify = addressCitiesRepository.Post(adress)
    if verify :
        return service.generate_response(201, False, False, "registered successfully!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

@addressCities.route('/addressCities/<id>', methods=["put"])
def Put(id):
    body = request.get_json()

    adress = address_cities(name = body["name"],address_state_id = body["address_state_id"])

    verify = addressCitiesRepository.Put(id,adress)
    if verify :
        return service.generate_response(200, False, False, "Updated successfully!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

@addressCities.route('/addressCities/<id>', methods=["DELETE"])
def Delete(id):
    verify = addressCitiesRepository.Delete(id)
    if verify :
        return service.generate_response(200, False, False, "successfully deleted!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")