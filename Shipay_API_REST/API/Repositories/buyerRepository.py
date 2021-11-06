from Models.buyersModel import buyers
from flask import current_app

class buyersRepository():
    def Get():
        ListBuyers = buyers.query.all()
        buyer_Json = [adress.to_json() for adress in ListBuyers]
        return buyer_Json

    def GetById(id):
        buyer = buyers.query.filter_by(id = id).first()

        if buyer:
            buyer_json = buyer.to_json()
            return buyer_json
        else:
            return False

    def Post(buyer:buyers):
        if buyer.address == "" or buyer.document == "" or buyer.last_name == "" or buyer.phone == "" or buyer.email == "" or buyer.updated_at == "" or buyer.created_at == "": 
            return False

        try:
            current_app.db.session.add(buyer)
            current_app.db.session.commit()
            return True
            
        except Exception as e:
            return False

    def Put(id, buyer:buyers):
       city = buyers.query.filter_by(id = id).first()
       try:
            city.address = (buyer.address != "" and buyer.address or city.address)
            city.last_name = (buyer.last_name != "" and buyer.last_name or city.last_name)
            city.phone = (buyer.phone != "" and buyer.phone or city.phone)
            city.email = (buyer.email != "" and buyer.email or city.email)
            city.updated_at = (buyer.updated_at != "" and buyer.updated_at or city.updated_at)
            city.created_at = (buyer.created_at != "" and buyer.created_at or city.created_at)
            city.document = (buyer.document != "" and buyer.document or city.document)
            city.address = (buyer.address != "" and buyer.address or city.address)

            current_app.db.session.merge(city)
            current_app.db.session.commit()
            return True

       except Exception as e:
        print(e)
        return False

    def Delete(id):
        try:
            current_app.db.session.query(buyers).filter(buyers.id==id).delete()
            current_app.db.session.commit()
            return True
        except Exception as e:
            print(e)
            return False