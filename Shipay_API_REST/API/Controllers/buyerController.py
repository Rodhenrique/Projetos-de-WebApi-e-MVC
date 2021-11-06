from flask import Blueprint,request
from Repositories.buyerRepository import buyersRepository
from Repositories.serviceRepository import service
from Models.buyersModel import buyers

buyersRoute = Blueprint('buyers', __name__)

@buyersRoute.route('/buyers', methods=["get"])
def Get():
    listBuyers = buyersRepository.Get()

    return service.generate_response(200, "buyers", listBuyers)

@buyersRoute.route('/buyers/<id>', methods=["get"])
def GetById(id):
    buyer = buyersRepository.GetById(id)
    if buyer == False:
        return service.generate_response(400, False, False, "An error has occurred!!!")

    try:
        return service.generate_response(200, "buyers", buyer)
    except:
        return service.generate_response(400, False, False, "An error has occurred!!!")


@buyersRoute.route('/buyers', methods=["post"])
def Post():
    body = request.get_json()

    buyer = buyers(created_at = body["created_at"],updated_at = body["updated_at"], first_name = body["first_name"], last_name = body["last_name"],document = body["document"],email = body["email"],phone = body["phone"],address = body["address"],address_city_id = body["address_city_id"])

    verify = buyersRepository.Post(buyer)
    if verify :
        return service.generate_response(201, False, False, "registered successfully!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

@buyersRoute.route('/buyers/<id>', methods=["put"])
def Put(id):
    body = request.get_json()

    buyer = buyers(created_at = body["created_at"],updated_at = body["updated_at"], first_name = body["first_name"], last_name = body["last_name"],document = body["document"],email = body["email"],phone = body["phone"],address = body["address"],address_city_id = body["address_city_id"])

    verify = buyersRepository.Put(id,buyer)
    if verify :
        return service.generate_response(200, False, False, "Updated successfully!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")

@buyersRoute.route('/buyers/<id>', methods=["DELETE"])
def Delete(id):
    verify = buyersRepository.Delete(id)
    if verify :
        return service.generate_response(200, False, False, "successfully deleted!!!")
    else:
        return service.generate_response(400, False, False, "An error has occurred!!!")
