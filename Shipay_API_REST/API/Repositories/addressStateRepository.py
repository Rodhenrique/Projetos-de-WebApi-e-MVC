from Models.addressState import address_states
from flask import current_app

class addressStateRepository():
    def Get():
        ListStates = address_states.query.all()
        state_Json = [adress.to_json() for adress in ListStates]
        return state_Json

    def GetById(id):
        city = address_states.query.filter_by(id = id).first()

        if city:
            city_json = city.to_json()
            return city_json
        else:
            return False

    def Post(addressState:address_states):
        if addressState.name == "" or addressState.uf == "":
            return False

        try:
            current_app.db.session.add(addressState)
            current_app.db.session.commit()
            return True
            
        except Exception as e:
            return False

    def Put(id, addressState:address_states):
       city = address_states.query.filter_by(id = id).first()
       try:
            city.name = (addressState.name != "" and addressState.name or city.name)
            city.uf = (addressState.uf != "" and addressState.uf or city.uf)
            current_app.db.session.merge(city)
            current_app.db.session.commit()
            return True

       except Exception as e:
        return False

    def Delete(id):
        try:
            current_app.db.session.query(address_states).filter(address_states.id==id).delete()
            current_app.db.session.commit()
            return True
        except Exception as e:
            print(e)
            return False