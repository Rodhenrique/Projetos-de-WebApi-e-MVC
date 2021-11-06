from Models.addressCities import address_cities
from flask import current_app

class addressCitiesRepository():
    def Get():
        ListCities = address_cities.query.all()
        cities_json = [adress.to_json() for adress in ListCities]
        return cities_json

    def GetById(id):
        city = address_cities.query.filter_by(id = id).first()
        city_json = city.to_json()
        return city_json

    def Post(addressCity:address_cities):
        if addressCity.name == "" or addressCity.address_state_id == 0:
            return False

        try:
            current_app.db.session.add(addressCity)
            current_app.db.session.commit()
            return True
            
        except Exception as e:
            return False

    def Put(id, addressCity:address_cities):
       city = address_cities.query.filter_by(id = id).first()
       try:
            city.name = (addressCity.name != "" and addressCity.name or city.name)
            city.address_state_id = (addressCity.address_state_id != 0 and addressCity.address_state_id or city.address_state_id)
            current_app.db.session.merge(city)
            current_app.db.session.commit()
            return True

       except Exception as e:
        return False

    def Delete(id):
        try:
            current_app.db.session.query(address_cities).filter(address_cities.id==id).delete()
            current_app.db.session.commit()
            return True
        except Exception as e:
            print(e)
            return False